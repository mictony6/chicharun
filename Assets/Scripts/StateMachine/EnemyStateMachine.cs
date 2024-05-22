using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;


public enum EnemyType
{
    Melee,
    Ranged,
    Boss
}
public class EnemyStateMachine : MonoBehaviour, BaseStateMachine
{

    [SerializeField] public EnemyType enemyType;
    public Animator animator;
    public CombatBehavior combatBehavior;

    Dictionary<EnemyStateTypes, IState> states = new Dictionary<EnemyStateTypes, IState>();

    private EnemyStateTypes _prevState;
    private EnemyStateTypes _currentState;
    private EnemyStateTypes _nextState;

    public GameObject targetPlayer;
    public Vector2 playerLastLocation;
    public Vector2 targetLocation;
    public Vector2 chaseDirection;

    [SerializeField] public GameObject deathParticle;
    [SerializeField] public GameObject projectilePrefab;

    // timer stuff
    public float attackInterval = 1.0f;
    public float timeTillNextAttack = 1.0f;
    public bool canAttack = false;



    public Rigidbody2D rigidBody { get; internal set; }
    public int speed = 75; 

    private void Start()
    {
        targetPlayer = GameObject.Find("Player");
        rigidBody = GetComponent<Rigidbody2D>();
        combatBehavior = GetComponent<CombatBehavior>();
        if (enemyType == EnemyType.Boss)
        {
            animator = GetComponent<Animator>();
        }
 


        InitStates();
        _currentState =  EnemyStateTypes.Chase;
    }

    void InitStates()
    {
        states[EnemyStateTypes.Chase] = new EnemyChase(this);
        states[EnemyStateTypes.Attack]= new EnemyAttack(this);
        states[EnemyStateTypes.Death] = new EnemyDeath(this);
        states[EnemyStateTypes.Idle] = new EnemyIdle(this);
    }

    void Update()
    {
        if (targetPlayer == null)
        {
            TransitionTo(EnemyStateTypes.Death);
            return;
        }

        if (timeTillNextAttack <= 0 )
        {
            canAttack = true;
            timeTillNextAttack = attackInterval;
        }
        else
        {
            timeTillNextAttack -= Time.deltaTime;
        }


        if (combatBehavior.currentHealth <= 0)
        {
            TransitionTo(EnemyStateTypes.Death);
        }

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (_nextState != _currentState)
        {

            states[_currentState].OnExit();
            _prevState = _currentState;
            _currentState = _nextState;
            states[_currentState].OnEnter();


        }
        states[_currentState].OnUpdate();



    }

    public void TransitionTo(EnemyStateTypes nextState)
    {

        _nextState = nextState;
    }

    public void TransitionToPrev()
    {
        _nextState = _prevState;
    }
}
