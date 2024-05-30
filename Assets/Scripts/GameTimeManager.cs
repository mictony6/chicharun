using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimeManager : MonoBehaviour
{
    private const float maxGameTime = 600;
    private int[] mileStones = {600-60, 600-(3*60), 600-(5*60), 600-(8*60), 600};
    private int currentMileStone = 0;
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

            if(timeTillGameOver <= mileStones[currentMileStone]){
                GameEvents.current.MileStoneAchieved.Invoke(currentMileStone);
                currentMileStone +=1;
            }
        }
    }

    void OnGameTimerElapsed()
    {
        GameEvents.current.BadEnding.Invoke();
        SceneManager.LoadScene("Bad Ending", LoadSceneMode.Single);
    }
    public void OnAttackLand()
    {
        StartCoroutine(TimeFreeze(0.25f));

    }

    void OnBulletTime(float seconds)
    {
        StartCoroutine(TimeFreeze(seconds));

    }
    IEnumerator TimeFreeze(float seconds)
    {
        yield return new WaitForSecondsRealtime(0.15f);

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
