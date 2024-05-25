using System;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
public class EnemyChase : EnemyState
{
    public float rayDistance = 0.5f; // Length of the raycast
    public EnemyChase(EnemyStateMachine enemy) : base(enemy)
    {
    }

    public override void OnEnter()
    {
        enemy.chaseDirection = GetDirectionToPlayer();
        enemy.rigidBody.bodyType = RigidbodyType2D.Dynamic;


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
                case EnemyType.Melee:
                    MeleeChase();
                    break;
                case EnemyType.Ranged:
                    RangedChase();
                    break;
                case EnemyType.Boss:
                    BossChase();
                    break;
            }



        }
        else
        {
            enemy.TransitionTo(EnemyStateTypes.Death);
        }


    }

    private void BossChase()
    {
        float distanceFromPlayer = (enemy.transform.position - enemy.targetPlayer.transform.position).sqrMagnitude;
        if (distanceFromPlayer < 20.0f)
        {
            if (enemy.canAttack)
            {
                enemy.TransitionTo(EnemyStateTypes.Attack);
            }

        }

        enemy.chaseDirection = GetDirectionToPlayer();
        enemy.animator.SetFloat("xDir", enemy.chaseDirection.x);
        enemy.rigidBody.velocity = enemy.chaseDirection * (enemy.speed * Time.deltaTime);
    }

    private void RangedChase()
    {
        float distanceFromPlayer = (enemy.transform.position - enemy.targetPlayer.transform.position).sqrMagnitude;
        if (distanceFromPlayer < 20.0f && enemy.canAttack)
        {

            enemy.TransitionTo(EnemyStateTypes.Attack);
        }
        else if (distanceFromPlayer < 20.0f && !enemy.canAttack)
        {
            enemy.chaseDirection = Vector2.zero;
            enemy.rigidBody.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            enemy.rigidBody.bodyType = RigidbodyType2D.Dynamic;
            enemy.chaseDirection = GetDirectionToPlayer();
            enemy.rigidBody.velocity = enemy.chaseDirection * (enemy.speed * Time.deltaTime);

        }

    }

    private void MeleeChase()
    {
        float distanceFromPlayer = (enemy.transform.position - enemy.targetPlayer.transform.position).sqrMagnitude;
        if (distanceFromPlayer < 10.0f)
        {
            if (enemy.canAttack)
            {
                enemy.TransitionTo(EnemyStateTypes.Attack);
            }

        }

        enemy.chaseDirection = GetDirectionToPlayer();
        enemy.rigidBody.velocity = enemy.chaseDirection * (enemy.speed * Time.deltaTime);


    }

    private Vector2 GetDirectionToPlayer()
    {
        if (enemy.targetPlayer && enemy.canAttack)
        {
            return (enemy.targetPlayer.transform.position - enemy.transform.position).normalized;
        }

        return Vector2.zero;
    }

}