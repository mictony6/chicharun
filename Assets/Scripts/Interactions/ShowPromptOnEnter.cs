using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPromptOnEnter : MonoBehaviour
{
    private GameObject prompt;
    private bool playerNearby = false;


    void Start()
    {
        prompt = GameObject.Find("Prompt");
        HidePrompt();
    }

    private void Update()
    {
        if (playerNearby)
        {
            if (Input.GetKeyDown(KeyCode.E)) {
                GameEvents.current.SummonBoss.Invoke();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ShowPrompt();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            HidePrompt();
        }
    }

    void ShowPrompt()
    {
        playerNearby = true;
        prompt.SetActive(true);
    }

    void HidePrompt()
    {
        playerNearby = false;
        prompt.SetActive(false);
    }
}
