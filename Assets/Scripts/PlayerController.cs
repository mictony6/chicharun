using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector2 direction;
    private Rigidbody2D playerRb;
    [SerializeField] float SPEED;
    [SerializeField] float STOP_FRICTION;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();

        if (direction.sqrMagnitude > 0)
        {
            playerRb.velocity = direction * SPEED * Time.deltaTime;
        }
        else
        {
            playerRb.velocity = Vector2.Lerp(playerRb.velocity, Vector2.zero, STOP_FRICTION * Time.deltaTime);
        }


    }

    private void GetInput()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        direction.Normalize();
    }

}
