using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawning : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    private GameObject projectileReadyToSpawn;

    private GameObject nearestEnemy;

    private List<GameObject> projectilePool = new List<GameObject>();
    private List<GameObject> enemiesInRange = new List<GameObject>();

    private int poolSize;

    [SerializeField] public float spawnInterval = 0.5f;

    private bool needToSpawn = true;

    private Vector3 difference;
    private float distance = Mathf.Infinity;

    void Start()
    {
        poolSize = Mathf.CeilToInt(GetComponent<Renderer>().bounds.extents.x / projectile.GetComponent<ProjectileMovement>().speed / spawnInterval + 1);
        
        for (int i = 0; i < poolSize; i++)
        {
            projectilePool.Add(Instantiate(projectile, transform.parent.gameObject.transform));
            projectilePool[i].SetActive(false);
        }
    }

    void Update()
    {
        GetNearestEnemy();

        if (needToSpawn && enemiesInRange.Count > 0)
        {
            needToSpawn = false;
            StartCoroutine(SpawnProjectiles());
        }

        if (nearestEnemy != null && !nearestEnemy.activeInHierarchy)
        {
            enemiesInRange.Remove(nearestEnemy);
            nearestEnemy = null;
            distance = Mathf.Infinity;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.gameObject == nearestEnemy)
            {
                nearestEnemy = null;
                distance = Mathf.Infinity;
            }

            enemiesInRange.Remove(other.gameObject);
        }
    }

    void GetNearestEnemy()
    {
        foreach (GameObject enemy in enemiesInRange)
        {
            difference = enemy.transform.position - transform.position;

            if (difference.sqrMagnitude < distance)
            {
                distance = difference.sqrMagnitude;
                nearestEnemy = enemy;
            }
        }

        //Point to the nearest enemy
        if (nearestEnemy != null)
        {
            Debug.DrawLine(transform.position, nearestEnemy.transform.position, Color.red, 0.001f);
        }
    }

    GameObject GetInactiveProjectile()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!projectilePool[i].activeInHierarchy)
            {
                return projectilePool[i];
            }
        }

        return null;
    }

    IEnumerator SpawnProjectiles()
    {
        projectileReadyToSpawn = GetInactiveProjectile();

        if (projectileReadyToSpawn != null)
        {
            yield return new WaitForSeconds(spawnInterval);
            projectileReadyToSpawn.transform.position = transform.position;
            projectileReadyToSpawn.SetActive(true);
            projectileReadyToSpawn.GetComponent<ProjectileMovement>().origin = transform.parent.gameObject;
            projectileReadyToSpawn.GetComponent<ProjectileMovement>().target = nearestEnemy;
        }

        needToSpawn = true;
    }
}