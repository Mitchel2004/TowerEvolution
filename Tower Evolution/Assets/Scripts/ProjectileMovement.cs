using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float speed = 25f;

    public GameObject origin;
    public GameObject target;

    private float targetWalkedDistance;
    private float projectileShootingDistance;
    private float projectileTravelTime;

    private Vector3 predictedTargetPosition;
    private Vector3 hitPosition;

    void Start()
    {
        //projectileShootingDistance = Vector3.Distance(origin.transform.position, target.transform.position);
        //projectileTravelTime = projectileShootingDistance / speed;

        //targetWalkedDistance = target.GetComponent<EnemyMovement>().speed * (origin.GetComponentInChildren<ProjectileSpawning>().spawnInterval + projectileTravelTime);

        //predictedTargetPosition = target.transform.position + target.transform.forward * targetWalkedDistance;

        //projectileShootingDistance = Vector3.Distance(origin.transform.position, predictedTargetPosition);
        //projectileTravelTime = projectileShootingDistance / speed;

        //targetWalkedDistance = target.GetComponent<EnemyMovement>().speed * projectileTravelTime;

        //hitPosition = target.transform.position + target.transform.forward * targetWalkedDistance;
    }

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target.transform.position) <= 0.001f)
            {
                gameObject.SetActive(false);
            }
        }
    }
}