using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticleFX : MonoBehaviour
{
    [SerializeField] GameObject particle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       GameObject.Instantiate(particle, transform.position, Quaternion.identity);
    }
}
