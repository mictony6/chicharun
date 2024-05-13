
using UnityEngine;

public class DeathState : PlayerState
{
    public DeathState(PlayerStateMachine player) : base(player)
    {
    }

    public override void OnEnter()
    {
        GameObject.Destroy(player.gameObject);
        player.gameOverUI.SetActive(true);
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }
}