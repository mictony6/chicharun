using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    public void OnAttackLand()
    {
        StartCoroutine(TimeFreeze());
    }

    IEnumerator TimeFreeze()
    {
        Time.timeScale = 0.25f;
        yield return new WaitForSecondsRealtime(0.05f);
        Time.timeScale = 1.0f;
    }
}
