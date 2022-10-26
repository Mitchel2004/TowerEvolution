using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] public float speed = 25f;

    public GameObject origin;
    public GameObject target;

    private float targetWalkDistance;
    private float projectileShootingDistance;
    private float projectileTravelTime;

    private Vector3 hitPosition;

    private bool canGetNewTarget = true;

    void Update()
    {
        if (target != null && target.activeInHierarchy)
        {
            // remove projectile when enemy is too close to waypoint
            //if (Vector3.Distance(target.transform.position, target.GetComponent<EnemyMovement>().waypoints[target.GetComponent<EnemyMovement>().index].position) <= 0.5f)
            //{
            //    transform.position = origin.transform.position;
            //    gameObject.SetActive(false);
            //}

            if (canGetNewTarget)
            {
                canGetNewTarget = false;

                projectileShootingDistance = Vector3.Distance(origin.transform.position, target.transform.position);
                projectileTravelTime = projectileShootingDistance / speed;

                targetWalkDistance = projectileTravelTime * target.GetComponent<EnemyMovement>().speed;

                hitPosition = target.transform.position + target.transform.forward * targetWalkDistance;
            }

            transform.position = Vector3.MoveTowards(transform.position, hitPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, hitPosition) <= 0.001f)
            {
                transform.position = origin.transform.position;
                target.GetComponentInChildren<EnemyHealth>().enemyHealth -= origin.GetComponent<TowerPlacement>().damage;
                canGetNewTarget = true;
                gameObject.SetActive(false);
            }
        }
        else
        {
            transform.position = origin.transform.position;
            gameObject.SetActive(false);
        }
    }
}