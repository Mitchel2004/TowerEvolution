using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    public int index = 0;

    public Quaternion startRotation;

    [SerializeField] public float speed = 2f;

    void Start()
    {
        foreach (GameObject waypoint in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            waypoints.Add(waypoint.transform);
        }

        startRotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, waypoints[0].position - transform.position, 1000 * Time.deltaTime, 0f));
        transform.rotation = startRotation;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, waypoints[index].position - transform.position, speed * 2 * Time.deltaTime, 0f));

        if (Vector3.Distance(transform.position, waypoints[waypoints.Count - 1].position) <= 0.001f)
        {
            GameObject.Find("Health Bar").GetComponent<PlayerHealth>().playerHealth -= 1;
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