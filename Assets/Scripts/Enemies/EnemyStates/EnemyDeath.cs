using UnityEngine;

public class EnemyDeath : EnemyState
{
    public EnemyDeath(EnemyStateMachine enemy) : base(enemy)
    {
    }

    public override void OnEnter()
    {
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