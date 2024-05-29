using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    EnemyStateMachine enemy;
    private SoundEffects soundManager;

    private void Start()
    {
        enemy = gameObject.GetComponent<EnemyStateMachine>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundEffects>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            GameEvents.current.AttackLand.Invoke();
            
            CombatBehavior playerCb = collision.gameObject.GetComponentInParent<CombatBehavior>();
            if (playerCb != null)
            {
                playerCb.TakeDamage(enemy.combatBehavior.GetDamage());
                // soundManager.PlayEnemyHitSfx();
            }
            enemy.TransitionTo(EnemyStateTypes.Death);
        }

    }



}
