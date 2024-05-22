using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGameOverScene : MonoBehaviour
{
    // Update is called once per frame
    void OnEnable()
    {
        // Go to the game over scene 
        SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
    }
}
