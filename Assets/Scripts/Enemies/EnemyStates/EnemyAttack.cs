using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyAttack : EnemyState
{
    public EnemyAttack(EnemyStateMachine enemy) : base(enemy)
    {
    }

    public override void OnEnter()
    {
        enemy.canAttack = false;


    }



    public override void OnExit()
    {
        enemy.rigidBody.bodyType = RigidbodyType2D.Dynamic;
        enemy.canAttack = false;
        if (enemy.enemyType == EnemyType.Boss)
        {
            enemy.animator.SetBool("isAttack", false);
        }


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
            case EnemyType.Boss:
                BossAttack2();
                break;
        }





    }

    private async void BossAttack1()
    {
        enemy.animator.SetBool("isAttack", true);

        enemy.animator.SetFloat("xDir", enemy.chaseDirection.x);
        if (enemy != null)
        {
            enemy.rigidBody.velocity = (enemy.chaseDirection * (enemy.speed * Time.deltaTime)) * 3;
        }
        enemy.canAttack = false;
        await WaitSeconds(enemy.combatBehavior.attackInterval);
        enemy.TransitionTo(EnemyStateTypes.Chase);
    }

    private async void BossAttack2()
    {
        if (!enemy.canAttack) return;
        enemy.animator.SetBool("isAttack", true);
        enemy.animator.SetFloat("xDir", enemy.chaseDirection.x);


        if (enemy != null)
        {
            enemy.rigidBody.velocity = (enemy.chaseDirection * (enemy.speed * Time.deltaTime)) * 3;
        }
        enemy.canAttack = false;



        await WaitSeconds(enemy.combatBehavior.attackInterval);

        int numProjectiles = 5;
        float angleStep = 360f / numProjectiles;
        float angle = 0f;
        for (int i = 0; i < numProjectiles; i++)
        {
            float projectileDirX = Mathf.Cos((angle * Mathf.PI) / 180f);
            float projectileDirY = Mathf.Sin((angle * Mathf.PI) / 180f);

            Vector3 projectileVector = new Vector3(projectileDirX, projectileDirY, 0);
            Vector3 projectileMoveDirection = (projectileVector).normalized * 5;
            Vector3 spawnPosition = enemy.transform.position;

            GameObject projectile = GameObject.Instantiate(enemy.projectilePrefab, spawnPosition, Quaternion.identity);
            projectile.GetComponent<DamageOnHit>().SetDamage(enemy.combatBehavior.GetDamage());
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += angleStep;
        }

        enemy.TransitionTo(EnemyStateTypes.Chase);
    }

    private async void MeleeAttack()
    {
        if (!enemy.canAttack) return;

        if (enemy != null)
        {
            enemy.rigidBody.AddForce(enemy.chaseDirection * 3, ForceMode2D.Impulse);
        }
        enemy.canAttack = false;
        await WaitSeconds(enemy.combatBehavior.attackInterval);
        enemy.TransitionTo(EnemyStateTypes.Chase);



    }
    private void RangedAttack()
    {
        enemy.canAttack = false;

        enemy.chaseDirection = GetDirectionToPlayer();

        GameObject projectile = GameObject.Instantiate(enemy.projectilePrefab, enemy.transform.position, Quaternion.identity);
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.velocity = enemy.chaseDirection * 5;
        projectile.GetComponent<DamageOnHit>().SetDamage(enemy.combatBehavior.GetDamage());
        enemy.TransitionTo(EnemyStateTypes.Chase);



    }
    private async Task WaitSeconds(float seconds)
    {
        await Task.Delay(TimeSpan.FromSeconds(seconds));
    }

    private Vector2 GetDirectionToPlayer()
    {
        return (enemy.targetPlayer.transform.position - enemy.transform.position).normalized;
    }

}