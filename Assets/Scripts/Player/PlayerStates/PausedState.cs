using UnityEngine;

public class PausedState : PlayerState
{
    public PausedState(PlayerStateMachine player) : base(player)
    {
    }

    public override void OnEnter()
    {
        player.rigidBody.velocity = Vector3.zero;
    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {

    }
}