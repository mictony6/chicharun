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

    }

    public override void OnUpdate()
    {
        if (enemy.targetPlayer == null) {
            enemy.TransitionTo(EnemyStateTypes.Death);
            return;
        }

        if (enemy.timeTillNextAttack <= 0)
        {
            enemy.canAttack = true;
            enemy.timeTillNextAttack = enemy.attackInterval;
        }
        else
        {
            enemy.timeTillNextAttack -= Time.deltaTime;
        }


        if (enemy.targetPlayer == null)
        {
            enemy.TransitionTo(EnemyStateTypes.Death);
        }

        float distanceFromPlayer = (enemy.transform.position - enemy.targetPlayer.transform.position).sqrMagnitude;
        


        switch (enemy.enemyType)
        {
            case EnemyType.Melee:
                if (distanceFromPlayer >= 10)
                {
                    enemy.TransitionTo(EnemyStateTypes.Chase);
                    enemy.rigidBody.bodyType = RigidbodyType2D.Dynamic;

                }
                break;
            case EnemyType.Ranged:
                if (distanceFromPlayer >= 20)
                {
                    enemy.TransitionTo(EnemyStateTypes.Chase);

                }
                break;
        }


        if (!enemy.canAttack) { return; }
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

    private void MeleeAttack()
    {
        if (enemy != null)
        {
            enemy.chaseDirection = GetDirectionToPlayer();
            enemy.rigidBody.velocity = (enemy.chaseDirection * (enemy.speed * Time.deltaTime)) * 3;
        }
        enemy.canAttack = false;


    }
    private void RangedAttack()
    {
        enemy.canAttack = false;
        enemy.chaseDirection = GetDirectionToPlayer();
        if (enemy.rigidBody.bodyType == RigidbodyType2D.Dynamic)
        {
            enemy.rigidBody.velocity = Vector2.zero;
        }
        enemy.rigidBody.bodyType = RigidbodyType2D.Static;
        GameObject projectile = GameObject.Instantiate(enemy.projectilePrefab, enemy.transform.position, Quaternion.identity);
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = enemy.chaseDirection * 5;
        projectile.GetComponent<DamageOnHit>().SetDamage(enemy.combatBehavior.damage);







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