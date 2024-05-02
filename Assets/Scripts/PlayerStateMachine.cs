using System.Collections;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    enum PlayerState
    {
        Move,
        Attack,

    }

    private PlayerController _playerController;
    private PlayerState _currentState;
    private PlayerState _nextState;

    private Rigidbody2D _playerRb;

    // Stats
    [SerializeField] private int speed;
    private float speedModifier = 1.0f;

    private WeaponBehavior weaponBehavior;



    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _playerRb = GetComponent<Rigidbody2D>();
        _currentState = PlayerState.Move;
        weaponBehavior = GameObject.Find("PlayerWeapon").GetComponent<WeaponBehavior>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _nextState = PlayerState.Attack;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_nextState != _currentState)
        {
            _currentState = _nextState;
        }


        switch (_currentState)
        {
            case PlayerState.Move:
                Move();
                break;
            case PlayerState.Attack:
                Attack();
                break;
        }

    }

    private void Attack()
    {
        _playerRb.velocity = Vector2.zero;
        // StartCoroutine(AttackRoutine());
        weaponBehavior.Shoot();
        _nextState = PlayerState.Move;

    }

    private IEnumerator AttackRoutine()
    {

        speedModifier = 0.0f;
        weaponBehavior.Shoot();
        _nextState = PlayerState.Move;
        yield return new WaitForSeconds(0.5f);
        speedModifier = 1.0f;

    }

    private void Move()
    {
        _playerRb.velocity = _playerController.direction * (speed * speedModifier * Time.deltaTime);


    }
}
