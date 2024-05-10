using System;
using UnityEngine;
public class EnemyChase : EnemyState
{

    public EnemyChase(EnemyStateMachine enemy) : base(enemy)
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
        if (enemy.targetPlayer)
        {
            switch (enemy.enemyType)
            {
                case EnemyType.Meelee:
                    MeleeChase();
                    break;
                case EnemyType.Ranged:
                    RangedChase();
                    break;
            }
        }
        else
        {
            enemy.TransitionTo(EnemyStateTypes.Death);
        }


    }

    private void RangedChase()
    {
        enemy.chaseDirection = GetDirectionToPlayer();
        enemy.rigidBody.velocity = enemy.chaseDirection * (enemy.speed * Time.deltaTime);
        float distanceFromPlayer = (enemy.transform.position - enemy.targetPlayer.transform.position).sqrMagnitude;
        if(distanceFromPlayer < 10.0f)
        {
            enemy.TransitionTo(EnemyStateTypes.Attack);
        }

    }

    private void MeleeChase()
    {
        enemy.chaseDirection = GetDirectionToPlayer();
        enemy.rigidBody.velocity = enemy.chaseDirection * (enemy.speed * Time.deltaTime);
    }

    private Vector2 GetDirectionToPlayer()
    {
        return (enemy.targetPlayer.transform.position - enemy.transform.position).normalized;
    }

}