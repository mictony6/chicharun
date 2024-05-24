using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum PowerUpType
{
    AttackUp,
    DefenseUp,
    SpeedUp,
}

public class PowerUpDetails : MonoBehaviour, IPointerClickHandler
{
    CombatBehavior playerCb;
    PlayerController playerController;
    [SerializeField] PowerUpType powerUpType;
    GameObject powerUpUI;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerCb = player.GetComponent<CombatBehavior>();
        playerController = player.GetComponent<PlayerController>();

        powerUpUI = GameObject.Find("PowerUpUI");
    }
    public void Apply()
    {
        switch(powerUpType)
        {
            case PowerUpType.AttackUp:
                playerCb.IncreaseDamage();
                break;

            case PowerUpType.DefenseUp:
                playerCb.IncreaseDefense();
                break;
            case PowerUpType.SpeedUp:
                playerController.speedModifier *= 1.15f;
                break;
        }
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        Apply();
        GameEvents.current.PowerUpUpdate.Invoke(powerUpType);
        powerUpUI.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
