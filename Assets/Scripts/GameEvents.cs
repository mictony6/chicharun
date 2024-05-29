using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onLevelUpTrigger;
    public void LevelUp()
    {
        if (onLevelUpTrigger != null)
        {
            onLevelUpTrigger();
        }
    }

    public UnityEvent<int> EnemyDeath;
    public UnityEvent BossDeath;

    public UnityEvent<PowerUpType> PowerUpUpdate;

    public UnityEvent AttackLand;
    public UnityEvent PauseGame;

    public UnityEvent ResumeGame;
    public UnityEvent CritAttack;
    public UnityEvent<float> BulletTime;

    public UnityEvent<GameObject> SpawnBoss;

    public UnityEvent GameOver;

    public UnityEvent SummonBoss;

    public UnityEvent<string> TimeTick;

    public UnityEvent<int> MileStoneAchieved;

    public UnityEvent GameWin;

    public UnityEvent HeartCollected;
}
