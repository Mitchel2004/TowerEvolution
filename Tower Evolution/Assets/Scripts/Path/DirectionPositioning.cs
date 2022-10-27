using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionPositioning : MonoBehaviour
{
    [SerializeField] private GameObject startPoint;
    private GameObject instantiatedStartPoint;

    [SerializeField] private GameObject endPoint;
    private GameObject instantiatedEndPoint;

    private List<Transform> routepoints;

    void Start()
    {
        routepoints = GetComponent<PathMaking>().routepoints;
        StartCoroutine(PositionDirection());
    }

    IEnumerator PositionDirection()
    {
        yield return new WaitForSeconds(0.1f);

        instantiatedStartPoint = Instantiate(startPoint, transform);

        instantiatedStartPoint.transform.position = new Vector3(transform.position.x, 0.003f, transform.position.z);
        instantiatedStartPoint.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, routepoints[1].position - transform.position, 1000 * Time.deltaTime, 0f));

        instantiatedEndPoint = Instantiate(endPoint, transform);

        instantiatedEndPoint.transform.position = new Vector3(routepoints[routepoints.Count - 1].position.x, 0.003f, routepoints[routepoints.Count - 1].position.z);
        instantiatedEndPoint.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(routepoints[routepoints.Count - 1].forward, routepoints[routepoints.Count - 1].position - routepoints[routepoints.Count - 2].position, 1000 * Time.deltaTime, 0f));
    }
}