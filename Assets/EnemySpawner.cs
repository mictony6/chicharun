using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject meleeEnemyPrefab;
    GameObject rangedEnemyPrefab;
    private float spawnRate;
    private float meleeSpawnChance;
    private float rangedSpawnChance;
    private float timeToNextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        meleeSpawnChance = 0.5f;
        spawnRate = 1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToNextSpawn <= 0)
        {
            float roll = Random.value;
            if (roll <= meleeSpawnChance)
            {
                GameObject.Instantiate(meleeEnemyPrefab, transform.position, Quaternion.identity);
            }
            timeToNextSpawn = spawnRate;
        }

        timeToNextSpawn -= Time.deltaTime;

        
    }
}
