using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum PowerUpType
{
    AttackUp,
    DefenseUp,
    SpeedUp,
}

public class PowerUpDetails : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Sprite hoverSprite;
    [SerializeField] Sprite normalSprite;
    CombatBehavior playerCb;
    PlayerController playerController;
    [SerializeField] PowerUpType powerUpType;
    GameObject powerUpUI;
    private Image image;

    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerCb = player.GetComponent<CombatBehavior>();
        playerController = player.GetComponent<PlayerController>();

        powerUpUI = GameObject.Find("PowerUpUI");
        image = GetComponent<Image>();
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
        GameEvents.current.ResumeGame.Invoke();

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(image != null){
            image.sprite = hoverSprite;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (image != null){
            image.sprite = normalSprite;

        }
    }
}
