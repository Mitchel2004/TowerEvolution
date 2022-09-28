using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private GameObject enemyReadyToSpawn;

    private List<GameObject> enemyPool = new List<GameObject>();
    private List<Transform> routepoints = new List<Transform>();

    private float walkDistance;
    private int poolSize;

    [SerializeField] private int enemiesToSpawn = 4;
    [SerializeField] private int enemiesToAdd = 2;  
    [SerializeField] private float spawnInterval = 1f;

    private bool needToSpawn = true;
    private int currentWave = 0;

    void Start()
    {
        routepoints.Add(transform);

        foreach (GameObject waypoint in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            routepoints.Add(waypoint.transform);
        }

        for (int i = 0; i < routepoints.Count - 1; i++)
        {
            walkDistance += Vector3.Distance(routepoints[i].position, routepoints[i + 1].position);
        }

        poolSize = Mathf.CeilToInt(walkDistance / enemy.GetComponent<EnemyMovement>().speed / spawnInterval + 1);

        for (int i = 0; i < poolSize; i++)
        {
            enemyPool.Add(Instantiate(enemy, transform));
            enemyPool[i].SetActive(false);
        }

        enemiesToSpawn -= enemiesToAdd;
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0 && needToSpawn)
        {
            needToSpawn = false;
            currentWave++;
            enemiesToSpawn += enemiesToAdd;
            GameObject.Find("Wave & Enemies").GetComponent<TextMeshProUGUI>().text = $"Wave: {currentWave}\nEnemies: {enemiesToSpawn}";
            StartCoroutine(SpawnEnemies());
        }

        if (enemiesToSpawn == 1000000000)
        {
            enemiesToAdd = 0;
            Debug.Log("Maximum Amount of Enemies Reached");
        }
    }

    GameObject GetInactiveEnemy()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!enemyPool[i].activeInHierarchy)
            {
                return enemyPool[i];
            }
        }

        return null;
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            enemyReadyToSpawn = GetInactiveEnemy();

            if (enemyReadyToSpawn != null)
            {
                yield return new WaitForSeconds(spawnInterval);
                enemyReadyToSpawn.transform.position = transform.position;
                enemyReadyToSpawn.transform.rotation = enemy.GetComponent<EnemyMovement>().startRotation;
                enemyReadyToSpawn.SetActive(true);
            }
        }

        needToSpawn = true;
    }
}