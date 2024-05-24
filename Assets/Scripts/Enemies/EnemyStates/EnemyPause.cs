using System;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyPause : EnemyState
{
    public EnemyPause(EnemyStateMachine enemy) : base(enemy)
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


}