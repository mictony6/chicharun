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
            enemy.chaseDirection = GetDirectionToPlayer();
            enemy.rigidBody.velocity = enemy.chaseDirection * (enemy.speed * Time.deltaTime);
        }
        else
        {
            enemy.TransitionTo(EnemyStateTypes.Death);
        }


    }

    private Vector2 GetDirectionToPlayer()
    {
        return (enemy.targetPlayer.transform.position - enemy.transform.position).normalized;
    }

}