using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    private bool isPaused;
    
    GameObject player;
    CombatBehavior playerCb;
    [SerializeField] private GameObject bulletPrefab;
    private Vector3 cursorPosition;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerCb = player.GetComponent<CombatBehavior>();
        GameEvents.current.PauseGame.AddListener(OnPause);
        GameEvents.current.ResumeGame.AddListener(OnResume);
    }
    // Update is called once per frame
    void Update()
    {
        if (isPaused) return;
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = cursorPosition - player.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        direction.Normalize();
        transform.position = player.transform.position + new Vector3(direction.x, direction.y, 0);


    }

    void OnPause(){
        isPaused = true;
    }

    void OnResume(){
        isPaused = false;
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = transform.right * 20;
        bullet.GetComponent<DamageOnHit>().SetDamage(playerCb.GetDamage());
    }
}
