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
    private float timeToNextSpawn;
    private bool active = true;

    private void Start()
    {
        GameEvents.current.PauseGame.AddListener(Stop);
        GameEvents.current.ResumeGame.AddListener(Resume);
    }

    void Stop()
    {
        active = false;
    }

    void Resume()
    {
        active = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (!active) return;
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
