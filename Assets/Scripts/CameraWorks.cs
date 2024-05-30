using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraWorks : MonoBehaviour
{

    [SerializeField] GameObject player;

    public float shakeDuration = 0.15f; // Duration of the shake effect
    public float shakeAmount = 0.1f; // Amount of shake

    Vector3 originalPos; // Original position of the camera

    private bool followPlayer = true;
    private Rigidbody2D rb;

    void Start(){
        GameEvents.current.AttackLand.AddListener(Shake);
        rb = gameObject.GetComponent<Rigidbody2D>();
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (rb != null){
                rb.velocity = (player.transform.position - transform.position).normalized * 100;
            }
        }


    }
    public void Shake()
    {
        if (transform != null)
        {
            originalPos = transform.position;
            StartCoroutine(ShakeCoroutine());
        }
    }
        IEnumerator ShakeCoroutine()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = originalPos.x + Random.Range(-shakeAmount, shakeAmount);
            float y = originalPos.y + Random.Range(-shakeAmount, shakeAmount);

            transform.position = new Vector3(x, y, -10);

            elapsed += Time.deltaTime;

            yield return null;
        }

    }
    

}
