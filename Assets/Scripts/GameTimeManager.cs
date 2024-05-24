using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameTimeManager : MonoBehaviour
{
    public void OnAttackLand()
    {
        // StartCoroutine(TimeFreeze());

    }

    IEnumerator TimeFreeze()
    {

        Time.timeScale = 0.25f;
        yield return new WaitForSecondsRealtime(0.025f);
        Time.timeScale = 1.0f;
    }

}
