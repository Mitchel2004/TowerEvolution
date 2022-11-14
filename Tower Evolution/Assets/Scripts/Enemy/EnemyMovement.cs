using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject waypointContainer;
    public List<Transform> waypoints = new List<Transform>();
    public int index = 0;

    public Quaternion startRotation;

    [SerializeField] public float speed = 2f;

    void Start()
    {
        waypointContainer = GameObject.Find("Waypoints");

        foreach (Transform waypoint in waypointContainer.transform)
        {
            waypoints.Add(waypoint);
        }

        startRotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, waypoints[0].position - transform.position, 1000 * Time.deltaTime, 0f));
        transform.rotation = startRotation;
    }

    void OnEnable()
    {
        transform.rotation = startRotation;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, waypoints[index].position - transform.position, speed * 2 * Time.deltaTime, 0f));

        if (Vector3.Distance(transform.position, waypoints[waypoints.Count - 1].position) <= 0.001f)
        {
            GameObject.Find("Health Bar").GetComponent<PlayerHealth>().playerHealth -= GetComponentInChildren<EnemyHealth>().enemyHealth;
            GetComponentInChildren<EnemyHealth>().enemyHealth = GetComponentInChildren<EnemyHealth>().totalEnemyHealth;
            index = 0;
            gameObject.SetActive(false);
        }
        else if (Vector3.Distance(transform.position, waypoints[index].position) <= 0.001f)
        {
            index++;
        }
    }
}