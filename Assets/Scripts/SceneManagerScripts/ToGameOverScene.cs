using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ToGameOverScene : MonoBehaviour
{

    [SerializeField] public Button quitButton;

void Start()
    {
        gameObject.SetActive(false);
        Button quitBtn = quitButton.GetComponent<Button>();

        quitBtn.onClick.AddListener(RestartGame);
}
    // Update is called once per frame
    void RestartGame()
    {
        // Go to the game over scene 
        SceneManager.LoadScene("Start Screen", LoadSceneMode.Single);
    }
}
