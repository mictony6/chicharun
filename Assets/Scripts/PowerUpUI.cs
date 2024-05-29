using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PowerUpUI : MonoBehaviour
{
    public GameObject whiteFlashPanel; // Reference to the white panel
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        whiteFlashPanel.SetActive(false);

        GameEvents.current.onLevelUpTrigger += OnLevelUp;
        GameEvents.current.PowerUpUpdate.AddListener(OnPowerUpClick);
    }

    private void OnPowerUpClick(PowerUpType arg0)
    {
        FlashWhite();
    }

    private async void OnLevelUp()
    {
        GameEvents.current.PauseGame.Invoke();

        FlashWhite();
        
        await Task.Delay(TimeSpan.FromSeconds(1.0f));
        gameObject.SetActive(true);
    }

    private async void FlashWhite()
    {
        // Activate the white flash panel
        whiteFlashPanel.SetActive(true);

        // Wait for a very short duration
        await Task.Delay(TimeSpan.FromSeconds(0.1f));

        // Deactivate the white flash panel
        whiteFlashPanel.SetActive(false);
    }




}
