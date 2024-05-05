using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    private Animator animator;

    Dictionary<EnemyStateTypes, IState> states = new Dictionary<EnemyStateTypes, IState>();

    private EnemyStateTypes _prevState;
    private EnemyStateTypes _currentState;
    private EnemyStateTypes _nextState;


   
    private static EnemyStateMachine _instance;

    private void Start()
    {

        _instance = this;


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

    public static EnemyStateMachine GetInstance()
    {
        return _instance;
    }

}
