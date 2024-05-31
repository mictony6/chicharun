using UnityEngine;

public class EnemyDeath : EnemyState
{
    private SoundEffects soundManager;
    public EnemyDeath(EnemyStateMachine enemy) : base(enemy)
    {
    }

    public void Start()
    {
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundEffects>();
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
        if(enemy.enemyType == EnemyType.Boss){
            GameEvents.current.BossDeath.Invoke();
            SoundEffects.current.PlayBossDeath();
            SoundEffects.current.PlayInGameMusic();
        }

        GameObject.Destroy(enemy.gameObject);


    }

    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {

    }

}