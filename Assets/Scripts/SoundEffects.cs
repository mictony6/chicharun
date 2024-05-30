using System;
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
    [SerializeField] private AudioClip inGameMusic;

    private AudioSource playerSfxSource;
    [SerializeField] AudioSource backgroundAudioSource;
    public static SoundEffects current;

    void Awake(){
        current = this;
    }
    void Start()
    {
        playerSfxSource = GetComponent<AudioSource>();
        PlayInGameMusic();
    }

    public void PlayExplosionSfx()
    {
        playerSfxSource.PlayOneShot(explosionSound, 0.6f);
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
        playerSfxSource.PlayOneShot(powerUpSound, 2f);
    }

    public void PlaySelectedPowerUp()
    {
        playerSfxSource.PlayOneShot(SelectPowerUpSound, 0.5f);
    }

    public void PlayBossSound()
    {
        playerSfxSource.Stop();
        playerSfxSource.clip = bossSound;
        playerSfxSource.Play();
    }

    public void PlayBossDeath()
    {
        playerSfxSource.PlayOneShot(bossDeathSound);
    }

    internal void PlayInGameMusic()
    {
        StartCoroutine(WaitAndPlayBackground());

    }

    private IEnumerator WaitAndPlayBackground()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        playerSfxSource.clip = inGameMusic;
        playerSfxSource.volume = 0.6f;
        playerSfxSource.Play();
    }
}
