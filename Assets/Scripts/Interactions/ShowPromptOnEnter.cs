using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPromptOnEnter : MonoBehaviour
{
    [SerializeField] GameObject prompt;
    private bool playerNearby = false;
    private bool canSummon = true;

    private SoundEffects soundManager;


    void Start()
    {
        // prompt = GameObject.Find("Prompt");
        HidePrompt();
        GameEvents.current.BossDeath.AddListener(OnBossDeath);
        soundManager = SoundEffects.current;
    }

    private void OnBossDeath()
    {
        canSummon = true;
        // soundManager.PlayBossDeath();
    }

    private void Update()
    {
        if (playerNearby)
        {
            if (Input.GetKeyDown(KeyCode.E)) {
                canSummon = false;
                GameEvents.current.SummonBoss.Invoke();
                HidePrompt();

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && canSummon)
        {
            ShowPrompt();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && canSummon)
        {
            HidePrompt();
        }
    }

    void ShowPrompt()
    {
        playerNearby = true;
        prompt.SetActive(true);
        // soundManager.PlayBossSound();
    }

    void HidePrompt()
    {
        playerNearby = false;
        prompt.SetActive(false);
    }
}
