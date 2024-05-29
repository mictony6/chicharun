using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Restart : MonoBehaviour
{
    [SerializeField] public Button continueButton;
    [SerializeField] public Button restartButton;

    [SerializeField] public Button quitButton;
    


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        Button contBtn = continueButton.GetComponent<Button>();
        Button restartBtn = restartButton.GetComponent<Button>();
        Button quitBtn = quitButton.GetComponent<Button>();

        contBtn.onClick.AddListener(continuePlay);
        restartBtn.onClick.AddListener(RestartGame);
        quitBtn.onClick.AddListener(QuitGame);
    
        void continuePlay()
        {
            gameObject.SetActive(false);
            GameEvents.current.ResumeGame.Invoke();
        }
}

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Start Screen");
    }
}
