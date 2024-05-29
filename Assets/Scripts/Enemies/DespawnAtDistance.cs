using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnAtDistance : MonoBehaviour
{
    GameObject player; // Reference to the player
    [SerializeField] float despawnDistance = 10f; // Distance at which the enemy should be despawned

    // Start is called before the first frame update
    void Start()
    {
        // Find the player object
        player = GameObject.Find("Player");
    }
    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }
        // Calculate the squared distance between the player and the enemy
        float squaredDistance = (player.transform.position - transform.position).sqrMagnitude;

        // If the squared distance is greater than the squared despawn distance, despawn the enemy
        if (squaredDistance > despawnDistance * despawnDistance)
        {
            Destroy(gameObject);
        }
    }
}
