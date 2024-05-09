using UnityEngine;

public class MovingState :  PlayerState
{
    public MovingState(PlayerStateMachine player) : base(player)
    {
    }

    public override void OnEnter()
    {
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
        if (player.playerController.direction.x == 0 && player.playerController.direction.y == 0)
        {
            player.TransitionTo(StateTypes.Idle);
        }
        player.rigidBody.velocity = player.playerController.direction * (player.playerController.GetSpeed() * Time.deltaTime);


    }
}