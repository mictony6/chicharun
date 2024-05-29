using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    private const float maxGameTime = 6000;
    private float timeTillGameOver = 0.0f;

    void Start()
    {
        timeTillGameOver = maxGameTime;
        GameEvents.current.PauseGame.AddListener(OnPauseGame);
        GameEvents.current.ResumeGame.AddListener(OnResumeGame);
        GameEvents.current.BulletTime.AddListener(OnBulletTime);
        GameEvents.current.AttackLand.AddListener(OnAttackLand);

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
        GameEvents.current.GameOver.Invoke();
    }
    public void OnAttackLand()
    {
        StartCoroutine(TimeFreeze(0.5f));

    }

    void OnBulletTime(float seconds)
    {
        StartCoroutine(TimeFreeze(seconds));

    }
    IEnumerator TimeFreeze(float seconds)
    {

        Time.timeScale = 0.25f;
        yield return new WaitForSecondsRealtime(seconds);
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
