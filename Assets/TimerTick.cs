using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerTick : MonoBehaviour
{
    private TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponentInChildren<TextMeshProUGUI>();
        GameEvents.current.TimeTick.AddListener(OnTimerTick);
    }

    private void OnTimerTick(string timeLeft)
    {
        timerText.text = timeLeft;
    }
}
