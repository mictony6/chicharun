using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject meleeEnemyPrefab;
    [SerializeField] GameObject rangedEnemyPrefab;
    [SerializeField] private float spawnRate;
    [SerializeField] private float meleeSpawnChance;
    [SerializeField] private float rangedSpawnChance;
    [SerializeField] private float timeToNextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        meleeSpawnChance = 0.5f;
        rangedSpawnChance = 0.25f;
        spawnRate = 1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToNextSpawn <= 0)
        {
            float roll = Random.value;
            if (roll <= rangedSpawnChance)
            {
                GameObject.Instantiate(rangedEnemyPrefab, transform.position, Quaternion.identity);
            }
            if (roll <= meleeSpawnChance)
            {
                GameObject.Instantiate(meleeEnemyPrefab, transform.position, Quaternion.identity);
            }

            timeToNextSpawn = spawnRate;
        }

        timeToNextSpawn -= Time.deltaTime;

        
    }
}
