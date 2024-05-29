using System;
using System.Collections;
using Unity.VisualScripting;
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
    public float critChance = 0.05f;
    public SoundManager soundEffects;

    [SerializeField] public float attackInterval = 0.75f;
    private float timeTillNextAttack;
    public bool canAttack = true;

    private bool isInvincible = false;


    void Start()
    {
        timeTillNextAttack = attackInterval;
        CombatBehavior.lastId += 1;
        this._id = CombatBehavior.lastId;

        this.currentHealth = maxHealth;
        soundEffects = GameObject.Find("SoundManager").GetComponent<SoundManager>();
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
        if (isInvincible)
        {
            Debug.Log("Is Invincible");
            return;
        }

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

        isInvincible = true;
        soundEffects.PlayPlayerHitSFX();
    }

    public int GetDamage()
    {
        if (WillCrit())
        {
            return (int)Mathf.Ceil(damage * damageModifier) * 2;
        }
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
            nextLevelThreshold *= 2;
            GameEvents.current.LevelUp();
        }
    }

    public void IncreaseAttackRate()
    {
        attackInterval -= 0.15f;
    }
    public void IncreaseMaxHealth()
    {
        maxHealth += 1;
        currentHealth = maxHealth;
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

    public void InceaseCrit()
    {
        critChance += 0.5f;
    }

    public bool WillCrit()
    {
        float randomRoll = UnityEngine.Random.Range(0.0f, 1.0f);
        if (randomRoll < critChance)
        {
            GameEvents.current.CritAttack.Invoke();
            return true;
        }
        return false;
    }


    void Update()
    {
        if (timeTillNextAttack <= 0)
        {
            canAttack = true;
            timeTillNextAttack = attackInterval;
        }
        else if (timeTillNextAttack > 0 && canAttack == false)
        {
            timeTillNextAttack -= Time.deltaTime;
        }

        if (isInvincible)
        {

            StartCoroutine(InvincibilityFrames());
        }
    }

    private IEnumerator InvincibilityFrames()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        Debug.Log("Is No Longer Invincible");
        isInvincible = false;
    }
}
