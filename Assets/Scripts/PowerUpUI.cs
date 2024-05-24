using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        GameEvents.current.onLevelUpTrigger += OnLevelUp;
    }



    private void OnLevelUp()
    {
        gameObject.SetActive(true);
        GameEvents.current.PauseGame.Invoke();
    }
}
