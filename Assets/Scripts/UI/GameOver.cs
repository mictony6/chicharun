using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {

        gameObject.SetActive(false);
        Button restartBtn = restartButton.GetComponent<Button>();
        Button quitBtn = quitButton.GetComponent<Button>();

        quitBtn.onClick.AddListener(() => SceneManager.LoadScene("Start Screen"));
        restartBtn.onClick.AddListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
