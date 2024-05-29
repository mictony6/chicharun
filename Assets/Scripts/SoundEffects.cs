using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private AudioClip lazerSound;
    // Start is called before the first frame update
    [SerializeField] private AudioClip playerHitSound;
    [SerializeField] private AudioClip enemyHitSound;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioClip powerUpSound;
    [SerializeField] private AudioClip SelectPowerUpSound;
    [SerializeField] private AudioClip bossSound;
    [SerializeField] private AudioClip bossDeathSound;
    private AudioSource playerSfxSource;
    void Start()
    {
        playerSfxSource = GetComponent<AudioSource>();
    }

    public void PlayExplosionSfx()
    {
        playerSfxSource.PlayOneShot(explosionSound);
    }

    public void PlayLazerSfx()
    {
        playerSfxSource.PlayOneShot(lazerSound, 0.25f);
    }
    
    public void PlayPlayerHitSfx()
    {
        playerSfxSource.PlayOneShot(playerHitSound, 0.5f);
    }

    public void PlayEnemyHitSfx()
    {
        playerSfxSource.PlayOneShot(enemyHitSound, 0.5f);
    }

    public void PlayDeathSfx()
    {
        playerSfxSource.PlayOneShot(deathSound);
    }

    public void PlayPowerUpSfx()
    {
        playerSfxSource.PlayOneShot(powerUpSound, 0.5f);
    }

    public void PlaySelectedPowerUp()
    {
        playerSfxSource.PlayOneShot(SelectPowerUpSound);
    }

    public void PlayBossSound()
    {
        playerSfxSource.PlayOneShot(bossSound);
    }

    public void PlayBossDeath()
    {
        playerSfxSource.PlayOneShot(bossDeathSound);
    }
}
