using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints = new List<Transform>();
    private int index = 0;

    [SerializeField] private float speed = 2f;

    void Start()
    {
        foreach (GameObject waypoint in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            waypoints.Add(waypoint.transform);
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, waypoints[index].position - transform.position, speed * 2 * Time.deltaTime, 0f));

        if (Vector3.Distance(transform.position, waypoints[waypoints.Count - 1].position) <= 0)
        {
            Destroy(gameObject);
        }
        else if (Vector3.Distance(transform.position, waypoints[index].position) <= 0)
        {
            index++;
        }
    }
}
