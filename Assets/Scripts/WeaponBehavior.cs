using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 cursorPosition;


    // Update is called once per frame
    void Update()
    {
    cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector3 direction = cursorPosition - player.transform.position;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    direction.Normalize();
    transform.position = player.transform.position +( direction * 2);

    }
}
