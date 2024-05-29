using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject meleeEnemyPrefab;
    [SerializeField] GameObject rangedEnemyPrefab;
    [SerializeField] GameObject bossEnemyPrefab;
    [SerializeField] private float spawnRate;
    [SerializeField] private float meleeSpawnChance;
    [SerializeField] private float rangedSpawnChance;
    [SerializeField] Transform playerTransform;
    [SerializeField] float spawnDistance;
    private float timeToNextSpawn;
    private bool active = true;

    private int[] expThreshold = { 100, 300, 400, 700, 1100 };

    private int spawnLevel = 0;
    private int totalExp = 0;
    private bool bossAlive = false;
    private bool canSummonBoss = false;

    private void Start()
    {
        GameEvents.current.PauseGame.AddListener(Stop);
        GameEvents.current.ResumeGame.AddListener(Resume);
        GameEvents.current.EnemyDeath.AddListener(OnEnemyDeath);
        GameEvents.current.SummonBoss.AddListener(SpawnBoss);
    }


    void Stop()
    {
        active = false;
    }

    void Resume()
    {
        active = true;
    }

    void OnEnemyDeath(int exp)
    {
        totalExp += exp;
        if (totalExp > expThreshold[spawnLevel])
        {
            spawnLevel += 1;
            if (spawnLevel >= expThreshold.Length)
            {
                //if (!bossAlive)
                //{
                //    Debug.Log("You can summon the boss now");
                //    canSummonBoss = true;
                //
                //}
                spawnLevel = expThreshold.Length - 1;
                return;
            }
            IncreaseDifficulty();
        }
    }

    private void SpawnBoss()
    {
        Vector3 randomPos = GetRandomOffScreenPosition();
        Instantiate(bossEnemyPrefab, randomPos, Quaternion.identity);

    }

    void IncreaseDifficulty()
    {
        Debug.Log("Difficulty Increased");
        spawnRate *= 0.95f;


    }


    // Update is called once per frame
    void Update()
    {
        if (playerTransform == null)
        {
            active = false;
        }
        if (!active) return;

        if (timeToNextSpawn <= 0)
        {
            float roll = Random.value;
            if (roll <= rangedSpawnChance)
            {
                Vector3 randomPos = GetRandomOffScreenPosition();

                GameObject.Instantiate(rangedEnemyPrefab, randomPos, Quaternion.identity);
            }
            if (roll <= meleeSpawnChance)
            {
                Vector3 randomPos = GetRandomOffScreenPosition();

                GameObject.Instantiate(meleeEnemyPrefab, randomPos, Quaternion.identity);
            }

            timeToNextSpawn = spawnRate;
        }

        timeToNextSpawn -= Time.deltaTime;


    }

    Vector3 GetRandomOffScreenPosition()
    {
        Vector3 playerPosition = playerTransform.position;
        float raandomAngle = Random.Range(0f, 360f);
        float spawnDistanceX = spawnDistance + Random.Range(0f, 5f);
        float spawnDistanceY = spawnDistance + Random.Range(0f, 5f);

        Vector3 offset = new Vector3(
            Mathf.Cos(raandomAngle) * spawnDistanceX,
            Mathf.Sin(raandomAngle) * spawnDistanceY, 0
        );

        return playerPosition + offset;

    }

}
