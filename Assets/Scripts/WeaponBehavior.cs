using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    GameObject player;
    CombatBehavior playerCb;
    [SerializeField] private GameObject bulletPrefab;
    private Vector3 cursorPosition;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerCb = player.GetComponent<CombatBehavior>();
    }
    // Update is called once per frame
    void Update()
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = cursorPosition - player.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        direction.Normalize();
        transform.position = player.transform.position + new Vector3(direction.x, direction.y, 0);


    }



    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * 20;
        bullet.GetComponent<DamageOnHit>().SetDamage(playerCb.GetDamage());
    }
}
