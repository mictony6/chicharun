using UnityEngine;

public class EnemyAttack : EnemyState
{
    public EnemyAttack(EnemyStateMachine enemy) : base(enemy)
    {
    }

    public override void OnEnter(){
        CombatBehavior playerCb = enemy.targetPlayer.GetComponent<CombatBehavior>();
        playerCb.TakeDamage(enemy.combatBehavior.damage);
        enemy.TransitionTo(EnemyStateTypes.Death);
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }


}