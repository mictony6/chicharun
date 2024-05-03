using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    int damage = 0;

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Bullet"))
        {
            CombatBehavior targetCb = collision.gameObject.GetComponent<CombatBehavior>();
            targetCb.TakeDamage(damage);
            Destroy(gameObject);
        }

    }


}
