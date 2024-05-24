using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModifierUI : MonoBehaviour
{
    private float value;
    [SerializeField] PowerUpType powerUpType;
    CombatBehavior playerCb;
    private PlayerController playerController;
    TextMeshProUGUI text;

    // Start is called before the first frame update


    private void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        GameObject player = GameObject.Find("Player");
        playerCb = player.GetComponent<CombatBehavior>();
        playerController = player.GetComponent<PlayerController>();
        GameEvents.current.PowerUpUpdate.AddListener(OnPowerUpChange);
        gameObject.SetActive(false);
    }
    void OnPowerUpChange(PowerUpType type)
    {
        if(type == powerUpType)
        {
            gameObject.SetActive(true);
            switch (type)
            {
                case PowerUpType.AttackUp:
                    if (playerCb.damageModifier <= 1.0f)
                    {
                        gameObject.SetActive(false);
                        return;
                    }
                    text.text = "x"+playerCb.damageModifier;
                    break;
                case PowerUpType.DefenseUp:
                    if (playerCb.GetDefense() <= 0)
                    {
                        gameObject.SetActive(false);
                        return;
                    }
                    text.text = ""+playerCb.GetDefense();
                    break;
                case PowerUpType.SpeedUp:
                    if (playerController.speedModifier <= 1)
                    {
                        gameObject.SetActive(false);
                        return;
                    }
                    text.text = "x"+playerController.speedModifier;
                    break;

            }   
        }

    }

}
