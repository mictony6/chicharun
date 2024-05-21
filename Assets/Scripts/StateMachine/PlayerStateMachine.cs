using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour, BaseStateMachine
{
    private Animator animator;

    Dictionary<StateTypes, IState> states = new Dictionary<StateTypes, IState>();

    private StateTypes _prevState;
    private StateTypes _currentState;
    private StateTypes? _nextState = null;

    public PlayerController playerController;
    public Rigidbody2D rigidBody;
    public WeaponBehavior weaponBehavior;
    public CombatBehavior combatBehavior;

    [SerializeField] public GameObject gameOverUI;

    private void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        rigidBody = GetComponent<Rigidbody2D>();
        weaponBehavior = GetComponentInChildren<WeaponBehavior>();
        combatBehavior = GetComponent<CombatBehavior>();


        InitStates();

        _currentState = StateTypes.Idle; ;
    }

    void InitStates()
    {
        states[StateTypes.Move] = new MovingState(this);
        states[StateTypes.Attack] = new AttackState(this);
        states[StateTypes.Idle] = new IdleState(this);
        states[StateTypes.Death] = new DeathState(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            _nextState = StateTypes.Attack;
        }


        animator.SetFloat("xDir", playerController.direction.x);
        animator.SetFloat("yDir", playerController.direction.y);

        animator.SetBool("moveY", (playerController.direction.y != 0));

        if (combatBehavior.currentHealth <= 0)
        {
            TransitionTo(StateTypes.Death);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (_nextState != null  && _nextState != _currentState)
        {

            states[_currentState].OnExit();
            _prevState = _currentState;
            _currentState = (StateTypes) _nextState;
            states[_currentState].OnEnter();

            switch (_prevState)
            {
                case StateTypes.Idle:
                    animator.SetBool("isIdle", false);
                    break;
                case StateTypes.Move:
                    animator.SetBool("isMoving", false);
                    break;
                case StateTypes.Attack:
                    animator.SetBool("isAttacking", false);
                    break;
            }
            switch (_currentState)
            {
                case StateTypes.Idle:
                    animator.SetBool("isIdle", true);
                    break;
                case StateTypes.Move:
                    animator.SetBool("isMoving", true);
                    break;
                case StateTypes.Attack:
                    animator.SetBool("isAttacking", true);
                    break;
            }

        }
        states[_currentState].OnUpdate();

    }

    public void TransitionTo(StateTypes nextState)
    {
        _nextState = nextState;
    }

    public void TransitionToPrev()
    {
        _nextState = _prevState;
    }
}
