using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWorks : MonoBehaviour
{

    [SerializeField] GameObject player;

    public float shakeDuration = 0.15f; // Duration of the shake effect
    public float shakeAmount = 0.1f; // Amount of shake

    Vector3 originalPos; // Original position of the camera

    void Start(){
        GameEvents.current.AttackLand.AddListener(Shake);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }

    }
    public void Shake()
    {
        if (transform != null)
        {
            StartCoroutine(ShakeCoroutine());
        }
    }
        IEnumerator ShakeCoroutine()
    {
        float elapsed = 0.0f;

        while (elapsed < shakeDuration)
        {
            float x = transform.position.x + Random.Range(-shakeAmount, shakeAmount);
            float y = transform.position.y + Random.Range(-shakeAmount, shakeAmount);

            transform.position = new Vector3(x, y, -10);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition =new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
