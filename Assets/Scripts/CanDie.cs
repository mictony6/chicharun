using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanDie : MonoBehaviour
{
    CombatBehavior cb;
    // Start is called before the first frame update
    void Start()
    {
        cb = GetComponent<CombatBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cb.currentHealth <= 0)
        {
            Destroy(gameObject);
        }    
    }
}
