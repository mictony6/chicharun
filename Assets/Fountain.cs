using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fountain : MonoBehaviour
{
    private bool active = false;
    [SerializeField] GameObject activeFountain;
    [SerializeField] GameObject disabledFountain;

    GameObject currentChild;


    // Start is called before the first frame update
    void Start()
    {
        GameObject fountain = Instantiate(disabledFountain, transform.position, Quaternion.identity);
        fountain.transform.SetParent(transform, true);
        GameEvents.current.BossDeath.AddListener(OnBossDeath);
        currentChild = fountain;

    }

    private void OnBossDeath()
    {
        active = true;
        Destroy(currentChild);
        GameObject fountain = Instantiate(activeFountain, transform.position, Quaternion.identity);
        fountain.transform.SetParent(transform, true);
        GameEvents.current.BossDeath.AddListener(OnBossDeath);
        currentChild = fountain;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(active && collision.CompareTag("Player")){
            GameEvents.current.GameWin.Invoke();
            Debug.Log("you Won");
        }

    }


}
