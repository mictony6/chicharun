using System;
using UnityEngine;

public class EnemyAttack : EnemyState
{
    public EnemyAttack(EnemyStateMachine enemy) : base(enemy)
    {
    }

    public override void OnEnter(){

        switch (enemy.enemyType)
        {
            case EnemyType.Meelee:
                MeleeAttack();
                break;
            case EnemyType.Ranged:
                RangedAttack();
                break;
        }

    }



    public override void OnExit()
    {
        enemy.canAttack = false;

    }

    public override void OnUpdate()
    {
        if (enemy.targetPlayer == null)
        {
            enemy.TransitionTo(EnemyStateTypes.Death);
        }

    }

    private void MeleeAttack()
    {
        CombatBehavior playerCb = enemy.targetPlayer.GetComponent<CombatBehavior>();
        playerCb.TakeDamage(enemy.combatBehavior.damage);
        enemy.TransitionTo(EnemyStateTypes.Death);
    }
    private void RangedAttack()
    {
        enemy.rigidBody.velocity = Vector2.zero;
        GameObject projectile = GameObject.Instantiate(enemy.projectilePrefab, enemy.transform.position, Quaternion.identity);
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = enemy.chaseDirection * 10;
        enemy.TransitionTo(EnemyStateTypes.Chase);


    }

}