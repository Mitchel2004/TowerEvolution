using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMaking : MonoBehaviour
{
    [SerializeField] private GameObject path;
    private GameObject instantiatedPath;

    [SerializeField] private GameObject pathEnd;
    private GameObject instantiatedPathEnd;

    private List<Transform> routepoints = new List<Transform>();

    private float scale;

    void Start()
    {
        routepoints.Add(transform);

        foreach (GameObject waypoint in GameObject.FindGameObjectsWithTag("Waypoint"))
        {
            routepoints.Add(waypoint.transform);
        }

        for (int i = 0; i < routepoints.Count - 1; i++)
        {
            instantiatedPath = Instantiate(path, routepoints[i]);

            instantiatedPath.transform.position = routepoints[i].position + (routepoints[i + 1].position - routepoints[i].position) / 2;
            instantiatedPath.transform.position = new Vector3(instantiatedPath.transform.position.x, 0.001f, instantiatedPath.transform.position.z);
            instantiatedPath.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(instantiatedPath.transform.forward, routepoints[i].position - routepoints[i + 1].position, 1000 * Time.deltaTime, 0f));
            instantiatedPath.transform.Rotate(90, 0, 0);

            scale = Vector3.Distance(routepoints[i].position, routepoints[i + 1].position);
            instantiatedPath.transform.localScale = new Vector3(1, scale, 1);
        }

        for (int i = 0; i < routepoints.Count; i++)
        {
            instantiatedPathEnd = Instantiate(pathEnd, routepoints[i]);

            instantiatedPathEnd.transform.position = new Vector3(instantiatedPathEnd.transform.position.x, 0, instantiatedPathEnd.transform.position.z);
        }
    }
}