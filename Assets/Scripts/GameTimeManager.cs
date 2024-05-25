using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
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
