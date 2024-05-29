using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissapearAtOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPosition.x < 0 || viewportPosition.x > 1 || viewportPosition.y < 0 || viewportPosition.y > 1)
        {
            StartCoroutine(Dissapear());
        }


    }

    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
