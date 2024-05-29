using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    private float lastHealth;
    CombatBehavior bossCb;
    GameObject boss;
    [SerializeField] Image currentHealthFill;
     [SerializeField] Image lastHealthFill;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        GameEvents.current.SpawnBoss.AddListener(OnBossSpawn);
    }

    private void OnBossSpawn(GameObject obj)
    {
        gameObject.SetActive(true);
        boss = obj;
        bossCb = boss.GetComponent<CombatBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if(boss != null){
            Debug.Log((float)bossCb.currentHealth/bossCb.maxHealth);
            currentHealthFill.fillAmount = (float)bossCb.currentHealth/bossCb.maxHealth;

        // Check if it's time to update the last health fill

            if(lastHealthFill.fillAmount -currentHealthFill.fillAmount <0.001f){
                lastHealthFill.fillAmount = currentHealthFill.fillAmount;
            }else{
                lastHealthFill.fillAmount = Mathf.Lerp(lastHealthFill.fillAmount, currentHealthFill.fillAmount, Time.deltaTime ); // Update last health fill

            }

        }



    }
}
