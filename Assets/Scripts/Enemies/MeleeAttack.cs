using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    EnemyStateMachine enemy;

    private void Start()
    {
        enemy = gameObject.GetComponent<EnemyStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            CombatBehavior playerCb = collision.gameObject.GetComponentInParent<CombatBehavior>();
            if (playerCb != null)
            {
                playerCb.TakeDamage(enemy.combatBehavior.GetDamage());
            }
            enemy.TransitionTo(EnemyStateTypes.Death);
        }

    }



}
