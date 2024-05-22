using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossIsAlive : MonoBehaviour
{
    private GameObject boss;

    // Start is called before the first frame update
    void Awake()
    {
        boss = GameObject.Find("BossEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the boss GameObject has been destroyed
        if (boss == null) 
        {
            // Load the Good Ending scene
            SceneManager.LoadScene("Good Ending", LoadSceneMode.Single);
        }
    }
}
