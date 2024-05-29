
using UnityEngine;

public class DeathState : PlayerState
{
    public DeathState(PlayerStateMachine player) : base(player)
    {
    }

    public override void OnEnter()
    {
        Debug.Log("PlayerDie EHHEHE");
        player.gameOverUI.SetActive(true);

        GameObject.Destroy(player.gameObject);

        // myrtlle put restart logic here
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }
}