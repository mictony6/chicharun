using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CombatBehavior : MonoBehaviour
{

    static int lastId = 0;
    private int _id;
    public int level;
    public int maxHealth;
    public int currentHealth;
    public int damage;
    private int defense = 0;

    public int exp;
    public float nextLevelThreshold;
    public int expDrop;
    public float damageModifier = 1;
    public float defenseModifier = 1;

    void Start()
    {
        CombatBehavior.lastId += 1;
        this._id = CombatBehavior.lastId;

        this.currentHealth = maxHealth;
    }

    public int GetId()
    {
        return this._id;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

    }

    public void TakeDamage(int amount)
    {
        if (defense > 0)
        {
            // do something effect chuchu
            defense -= 1;
            GameEvents.current.PowerUpUpdate.Invoke(PowerUpType.DefenseUp);
            return;
        }
        currentHealth -= amount;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public int GetDamage()
    {
        return (int)Mathf.Ceil(damage * damageModifier);
    }

    public void PrintStats()
    {
        Debug.Log("Name: " + name);
        Debug.Log("Level: " + level);
        Debug.Log("Health: " + currentHealth + "/" + maxHealth);
        Debug.Log("Damage: " + damage);
        Debug.Log("Defense: " + defense);
    }

    public void collectExp(int exp)
    {
        this.exp += exp;
        if (this.exp > nextLevelThreshold)
        {
            level += 1;
            nextLevelThreshold *=2;
            GameEvents.current.LevelUp();
        }
    }


    public void IncreaseDamage()
    {
        damageModifier += 0.5f;
    }

    public void IncreaseDefense()
    {
        defense += 1;
    }

    public float GetDefense()
    {
        return defense;
    }
}
