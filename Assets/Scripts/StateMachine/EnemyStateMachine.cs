using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyType
{
    Meelee,
    Ranged
}
public class EnemyStateMachine : MonoBehaviour, BaseStateMachine
{

    [SerializeField] public EnemyType enemyType;
    private Animator animator;
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
    private float attackInterval = 1.0f;
    private float timeTillNextAttack = 1.0f;
    public bool canAttack = true;


    public Rigidbody2D rigidBody { get; internal set; }
    public int speed = 100; 

    private void Start()
    {
        targetPlayer = GameObject.Find("Player");
        rigidBody = GetComponent<Rigidbody2D>();
        combatBehavior = GetComponent<CombatBehavior>();
 


        InitStates();
        _currentState =  EnemyStateTypes.Chase;
    }

    void InitStates()
    {
        states[EnemyStateTypes.Chase] = new EnemyChase(this);
        states[EnemyStateTypes.Attack]= new EnemyAttack(this);
        states[EnemyStateTypes.Death] = new EnemyDeath(this);

    }

    void Update()
    {
        if (timeTillNextAttack <= 0)
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
        if (nextState == EnemyStateTypes.Attack && !canAttack)
        {
            return;
        }
        _nextState = nextState;
    }

    public void TransitionToPrev()
    {
        _nextState = _prevState;
    }

 

}
