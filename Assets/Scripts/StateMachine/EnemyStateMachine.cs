using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private Animator animator;

    Dictionary<EnemyStateTypes, IState> states = new Dictionary<EnemyStateTypes, IState>();

    private EnemyStateTypes _prevState;
    private EnemyStateTypes _currentState;
    private EnemyStateTypes _nextState;

    public GameObject targetPlayer;
    public Vector2 playerLastLocation;
    public Vector2 targetLocation;
    public Vector2 chaseDirection;


    public Rigidbody2D rigidBody { get; internal set; }
    public int speed = 100; 

    private void Start()
    {
        targetPlayer = GameObject.Find("Player");
        rigidBody = GetComponent<Rigidbody2D>();
 


        InitStates();
        _currentState =  EnemyStateTypes.Chase;
    }

    void InitStates()
    {
        states[EnemyStateTypes.Chase] = new EnemyChase(this);
        states[EnemyStateTypes.Attack]= new EnemyAttack(this);
        states[EnemyStateTypes.Death] = new EnemyDeath(this);

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
