using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    enum PlayerState
    {
        Move,
        Attack,
        
    }

    private PlayerController _playerController;
    private PlayerState _currentState ;
    private PlayerState _nextState;
    
    private Rigidbody2D _playerRb;

    // Stats
    [SerializeField] private int speed;
    private float speedModifier = 1.0f;
    


    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _playerRb = GetComponent<Rigidbody2D>();
        _currentState = PlayerState.Move;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
        throw new System.NotImplementedException();
    }

    private void Move()
    {
        _playerRb.velocity = _playerController.direction * (speed * speedModifier * Time.deltaTime);

    }
}
