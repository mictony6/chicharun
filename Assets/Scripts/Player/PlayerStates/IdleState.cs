using Unity.VisualScripting;
using UnityEngine;

public class IdleState :  PlayerState
{
    public IdleState(PlayerStateMachine player) : base(player)
    {
    }

    public override void OnEnter()
    {
        player.rigidBody.velocity = Vector2.zero;
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            player.TransitionTo(StateTypes.Attack);
        }


        if (player.playerController.direction.x != 0 || player.playerController.direction.y != 0)
        {
            player.TransitionTo(StateTypes.Move);
        }
    }
}