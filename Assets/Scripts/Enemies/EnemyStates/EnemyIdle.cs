using System;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyIdle : EnemyState
{
    public EnemyIdle(EnemyStateMachine enemy) : base(enemy)
    {
    }

    public override void OnEnter()
    {
        enemy.rigidBody.velocity = Vector3.zero;


    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {

    }

    private async Task WaitSeconds(int seconds)
    {
        await Task.Delay(TimeSpan.FromSeconds(seconds));
    }

}