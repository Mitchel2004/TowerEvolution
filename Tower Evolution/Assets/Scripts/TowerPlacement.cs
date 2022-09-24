using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private Collider gameRange;

    private Vector3 mousePosition;
    private Vector3 placePosition;

    void Start()
    {
        gameRange = GameObject.Find("Game Range").GetComponent<Collider>();
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        placePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y - GetComponent<Renderer>().bounds.extents.y));

        transform.position = placePosition;

        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<TowerPlacement>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == gameRange)
        {
            GetComponent<Renderer>().enabled = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == gameRange)
        {
            GetComponent<Renderer>().enabled = false;
        }
    }
}