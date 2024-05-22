using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChichaIsAlive : MonoBehaviour
{
    private GameObject playerRb;

    // Start is called before the first frame update
    void Awake()
    {
        playerRb = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the playerRb GameObject has been destroyed
        if (playerRb == null) 
        {
            // Load the game over scene
            SceneManager.LoadScene("Game Over", LoadSceneMode.Single);
        }
    }
}
