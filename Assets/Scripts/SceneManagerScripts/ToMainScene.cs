using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToMainScene : MonoBehaviour
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
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
