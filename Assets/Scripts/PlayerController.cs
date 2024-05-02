using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{

    private Vector2 _direction;
    private Rigidbody2D _playerRb;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();


        _playerRb.velocity = _direction * (speed * Time.deltaTime);
        



    }

    private void GetInput()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.y = Input.GetAxis("Vertical");

        _direction.Normalize();
    }

}
