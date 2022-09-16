using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    
    [SerializeField] private int spawnAmount = 4;
    [SerializeField] private int spawnAmountIncrement = 2;
    private int enemiesToSpawn;

    [SerializeField] private float spawnInterval = 1f;
    private float instantiateTimer;
    
    void Start()
    {
        enemiesToSpawn = spawnAmount;
        instantiateTimer = spawnInterval;
    }

    void Update()
    {
        if (enemiesToSpawn > 0)
        {
            instantiateTimer -= Time.deltaTime;

            if (instantiateTimer <= 0)
            {
                Instantiate(enemy, gameObject.transform);
                enemiesToSpawn--;
                instantiateTimer = spawnInterval;
            }
        }
        else if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            spawnAmount += spawnAmountIncrement;
            enemiesToSpawn = spawnAmount;
        }
    }
}
