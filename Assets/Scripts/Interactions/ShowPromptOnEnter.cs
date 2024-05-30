using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowPromptOnEnter : MonoBehaviour
{
    [SerializeField] GameObject prompt;
    [SerializeField] GameObject exitPrompt;

    private bool playerNearby = false;
    private bool canSummon = true;
    private bool canExit = false;

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
        Debug.Log("Boss deadz");
        canExit = true;
        // soundManager.PlayBossDeath();
    }

    private void Update()
    {
        if (playerNearby)
        {
        Debug.Log("Player nearby...");

            if (Input.GetKeyDown(KeyCode.E)) {
                if(canExit){
                    GameEvents.current.GameWin.Invoke();
                    SceneManager.LoadScene("Good Ending", LoadSceneMode.Single);
                    return;
                }
                canSummon = false;
                GameEvents.current.SummonBoss.Invoke();
                HidePrompt();

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            if(canSummon){
                ShowPrompt();
            }
            if(canExit){
                playerNearby = true;
                exitPrompt.SetActive(true);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            if(canSummon){
                HidePrompt();
            }
            if(canExit){
                playerNearby = true;
                exitPrompt.SetActive(false);

            }
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
        exitPrompt.SetActive(false);
    }
}
