using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        Debug.Log(other);
        if(other.CompareTag("Player") ){
            Destroy(gameObject);
            GameEvents.current.HeartCollected.Invoke();
        }
    }
}
