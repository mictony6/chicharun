using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToStartScene : MonoBehaviour
{
    [Header("Button Reference")]
    [SerializeField] private Button button;

    private GameObject buttonRb;

    void Awake()
    {
        buttonRb = GameObject.Find("Button");
    }

    void Start()
    {
        if (buttonRb == null)
        {
            GoToStartScene();
        }

        else
        {
            button = GetComponent<Button>(); 

            // Get the id of the button that was selected
            button.onClick.AddListener(GoToStartScene);
        }
    }

    // Update is called once per frame
    void GoToStartScene()
    {
        SceneManager.LoadScene("Start Screen", LoadSceneMode.Single);
    }
}
