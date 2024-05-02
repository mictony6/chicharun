using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    enum PlayerState
    {
        Move,
        Attack,
        
    }

    private PlayerState _currentState;
    private PlayerState _nextState;
    


    // Update is called once per frame
    void Update()
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
        throw new System.NotImplementedException();
    }
}
