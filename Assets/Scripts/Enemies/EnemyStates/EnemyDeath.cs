using UnityEngine;

public class EnemyDeath : EnemyState
{
    public EnemyDeath(EnemyStateMachine enemy) : base(enemy)
    {
    }

    public override void OnEnter()
    {
        if (enemy.targetPlayer)
        {
            GameEvents.current.EnemyDeath.Invoke(enemy.combatBehavior.expDrop);
            // CombatBehavior playerCb = enemy.targetPlayer.GetComponent<CombatBehavior>();
            //playerCb.collectExp(enemy.combatBehavior.expDrop);
        }
        GameObject.Instantiate(enemy.deathParticle, enemy.transform.position, Quaternion.identity);
        GameObject.Destroy(enemy.gameObject);

    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {

    }

}