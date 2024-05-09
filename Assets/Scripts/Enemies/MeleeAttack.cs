using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CombatBehavior playerCb = player.GetComponent<CombatBehavior>();
        CombatBehavior enemyCb = gameObject.GetComponent<CombatBehavior>();
        playerCb.TakeDamage(enemyCb.damage);
        EnemyStateMachine enemy = gameObject.GetComponent<EnemyStateMachine>();
        enemy.TransitionTo(EnemyStateTypes.Death);


    }



}
