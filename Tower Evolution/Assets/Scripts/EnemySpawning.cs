using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    private string spawnedEnemyName;

    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private int spawnAmount = 4;
    [SerializeField] int spawnAmountIncrement = 2;
    private int spawnedAmount;

    void Start()
    {
        if (!GameObject.Find(spawnedEnemyName))
        {
            spawnedAmount = spawnAmount;
            StartCoroutine(SpawnEnemy());
        }
    }

    void Update()
    {
        if (!GameObject.Find(spawnedEnemyName))
        {
            spawnAmount += spawnAmountIncrement;
            spawnedAmount = spawnAmount;
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (spawnedAmount > 0)
        {
            yield return new WaitForSeconds(spawnInterval);

            GameObject spawnedEnemy = Instantiate(enemy, gameObject.transform);
            spawnedEnemyName = spawnedEnemy.name;
            spawnedAmount--;
        }
    }
}
