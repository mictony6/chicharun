using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyAttack : EnemyState
{
    public EnemyAttack(EnemyStateMachine enemy) : base(enemy)
    {
    }

    public override void OnEnter(){



    }



    public override void OnExit()
    {
        enemy.rigidBody.bodyType = RigidbodyType2D.Dynamic;
        enemy.canAttack = false;

    }

    public override void OnUpdate()
    {
        switch (enemy.enemyType)
        {
            case EnemyType.Melee:
                MeleeAttack();
                break;
            case EnemyType.Ranged:
                RangedAttack();
                break;
        }





    }

    private async void MeleeAttack()
    {
        if (enemy != null)
        {
            enemy.chaseDirection = GetDirectionToPlayer();
            enemy.rigidBody.velocity = (enemy.chaseDirection * (enemy.speed * Time.deltaTime)) * 3;
        }
        enemy.canAttack = false;
        enemy.timeTillNextAttack = enemy.attackInterval;
        await WaitSeconds(1);
        enemy.TransitionTo(EnemyStateTypes.Chase);



    }
    private async void RangedAttack()
    {
        enemy.canAttack = false;
        enemy.timeTillNextAttack = enemy.attackInterval;

        enemy.chaseDirection = GetDirectionToPlayer();
        if (enemy.rigidBody.bodyType == RigidbodyType2D.Dynamic)
        {
            enemy.rigidBody.velocity = Vector2.zero;
            enemy.rigidBody.bodyType = RigidbodyType2D.Static;
        }
        GameObject projectile = GameObject.Instantiate(enemy.projectilePrefab, enemy.transform.position, Quaternion.identity);
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = enemy.chaseDirection * 5;
        projectile.GetComponent<DamageOnHit>().SetDamage(enemy.combatBehavior.damage);
        enemy.TransitionTo(EnemyStateTypes.Chase);



    }
    private async Task WaitSeconds(int seconds)
    {
        await Task.Delay(TimeSpan.FromSeconds(seconds));
    }

    private Vector2 GetDirectionToPlayer()
    {
        return (enemy.targetPlayer.transform.position - enemy.transform.position).normalized;
    }

}