using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Overview: Script responsible for loading the mp4 scene

public class SceneManagerScript : MonoBehaviour
{
    [Header("Button Reference")]
    [SerializeField] private Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>(); 

        // Get the id of the button that was selected
        button.onClick.AddListener(LoadSceneManager);
    }

    // Load the next scene
    public void LoadSceneManager()
    {
        // Built index references
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        Debug.Log(currentIndex);
        Debug.Log(nextIndex);

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
