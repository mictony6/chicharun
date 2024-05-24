using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class DamageOnHit : MonoBehaviour
{
    int damage = 0;
    [SerializeField] string tagToDamage;
    [SerializeField] GameObject particle;


    public void SetDamage(int damage)
    {
        this.damage = damage;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagToDamage))
        {
            GameEvents.current.AttackLand.Invoke();
            Instantiate(particle, transform.position, Quaternion.identity);
            CombatBehavior targetCb = collision.gameObject.GetComponentInParent<CombatBehavior>();
            targetCb.TakeDamage(damage);
            Destroy(gameObject);

        }
    }



}
