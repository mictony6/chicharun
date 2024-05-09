using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthBarSystem : MonoBehaviour
{
    CombatBehavior combatBehavior;
    [SerializeField] GameObject player;
    [SerializeField] Image[] hearts;
    [SerializeField] Sprite filledHeart;
    [SerializeField] Sprite emptyHeart;

    private int lastHeath;
    // Start is called before the first frame update
    void Start()
    {
        combatBehavior = player.GetComponent<CombatBehavior>();
    }

    // Update is called once per frame
    void Update()
    {

        if (lastHeath == combatBehavior.currentHealth)
        {
            return;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i >= combatBehavior.maxHealth)
            {
                hearts[i].enabled = false;
            }
            else
            {
                hearts[i].enabled = true;
                if (i < combatBehavior.currentHealth)
                {
                    hearts[i].sprite = filledHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }
            }
        }


        lastHeath = combatBehavior.currentHealth;

    }
}
