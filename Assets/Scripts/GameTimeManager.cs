using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimeManager : MonoBehaviour
{
    private const float maxGameTime = 6000;
    private float timeTillGameOver = 0.0f;

    void Start()
    {
        timeTillGameOver = maxGameTime;

    }

    void Update()
    {
        if (timeTillGameOver <= 0)
        {
            OnGameTimerElapsed();
        }
        else
        {
            timeTillGameOver -= Time.deltaTime;
        }
    }

    void OnGameTimerElapsed()
    {
        GameEvents.current.BadEnding.Invoke();
        SceneManager.LoadScene("Bad Ending", LoadSceneMode.Single);
    }
    public void OnAttackLand()
    {
        // StartCoroutine(TimeFreeze());
        GameEvents.current.PauseGame.AddListener(OnPauseGame);
        GameEvents.current.ResumeGame.AddListener(OnResumeGame);
        GameEvents.current.BulletTime.AddListener(OnBulletTime);
    }

    void OnBulletTime(float seconds)
    {
        StartCoroutine(TimeFreeze(seconds));

    }
    IEnumerator TimeFreeze(float seconds)
    {

        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(seconds);
        Time.timeScale = 1.0f;
    }

    void OnPauseGame()
    {
        Time.timeScale = 0.0f;
    }

    void OnResumeGame()
    {
        Time.timeScale = 1.0f;
    }

}
