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
    public int defense;
    public int exp;
    public int nextLevelThreshold;

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
        currentHealth -= amount - defense;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    public void PrintStats()
    {
        Debug.Log("Name: " + name);
        Debug.Log("Level: " + level);
        Debug.Log("Health: " + currentHealth + "/" + maxHealth);
        Debug.Log("Damage: " + damage);
        Debug.Log("Defense: " + defense);
    }



}
