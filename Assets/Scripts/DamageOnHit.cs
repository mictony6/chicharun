using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageOnHit : MonoBehaviour
{
    int damage = 0;
    [SerializeField] string tagToDamage;

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagToDamage))
        {
            CombatBehavior targetCb = collision.gameObject.GetComponentInParent<CombatBehavior>();
            targetCb.TakeDamage(damage);
            Destroy(gameObject);
        } 
    }



}
