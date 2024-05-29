using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Overview: Script responsible for the sound effects of all game objects

public class SoundManager : MonoBehaviour
{
    [Header("Sound Effects")]
    [SerializeField] private AudioClip shootFX;
    [SerializeField] private AudioClip enemyHitFX;
    [SerializeField] private AudioClip playerHitFX;
    [SerializeField] private AudioClip playerDeathFX;
    [SerializeField] private AudioClip powerUpFX;
    [SerializeField] private AudioClip bossFX;
    [SerializeField] private AudioClip gameOverFX;

    private AudioSource playerSfxScource;

    // Start is called before the first frame update
    void Start()
    {
        playerSfxScource = GetComponent<AudioSource>();
    }

    // Plays this effect when the ghoul rises and dives on the grave
    public void PlayShootSFX()
    {
        playerSfxScource.PlayOneShot(shootFX, 0.5f);
    }

    public void PlayEnemyHitSFX()
    {
        playerSfxScource.PlayOneShot(enemyHitFX, 0.5f);
    }

    public void PlayPlayerHitSFX()
    {
        playerSfxScource.PlayOneShot(playerHitFX, 0.5f);
    }
    
    public void PlayPowerUpSFX()
    {
        playerSfxScource.PlayOneShot(powerUpFX, 0.5f);
    }

    public void PlayBossSFX()
    {
        playerSfxScource.PlayOneShot(bossFX, 0.5f);
    }

    public void PlayGameOverSFX()
    {
        playerSfxScource.PlayOneShot(gameOverFX, 0.5f);
    }
}