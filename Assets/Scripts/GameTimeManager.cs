using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    private const float maxGameTime = 600;
    private float timeTillGameOver = 0.0f;
    private string lastTime = "10:00";

    void Awake(){
        Time.timeScale = 1.0f;
    }
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
            // Convert float seconds to TimeSpan
            TimeSpan timeSpan = TimeSpan.FromSeconds(timeTillGameOver);

             // Format TimeSpan as string in 00:00 format
            string formattedTime = string.Format("{0:D2}:{1:D2}", (int)timeSpan.TotalMinutes, (int)(timeSpan.TotalSeconds%60));

            string currentTimeLeft  = formattedTime;
            if(lastTime != currentTimeLeft){
                GameEvents.current.TimeTick.Invoke(currentTimeLeft);
            }
            timeTillGameOver -= Time.deltaTime;
            lastTime = currentTimeLeft;
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

        Time.timeScale = 0.16f;
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
