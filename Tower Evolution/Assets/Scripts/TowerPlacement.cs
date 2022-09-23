using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    [SerializeField] private GameObject map;
    [SerializeField] private GameObject tower;

    private Vector3 mousePosition;
    private Vector3 placePosition;

    public Collider[] hitColliders;

    void Start()
    {
        
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        placePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y));

        hitColliders = Physics.OverlapSphere(placePosition, 1f);

        //foreach (Collider collider in hitColliders)
        //{
        //    Debug.Log(tower.GetComponent<Renderer>().bounds.extents.x);

        //    if (collider == map.GetComponent<Collider>())
        //    {
        //        mapCollider = collider;
        //    }
        //}

        if (Array.Exists(hitColliders, collider => map.GetComponent<Collider>() && tower.GetComponent<Collider>()))
        {
            tower.SetActive(true);
        }
        else
        {
            tower.SetActive(false);
        }

        tower.transform.position = placePosition;
    }

    public void Drag()
    {
        tower = Instantiate(tower);
    }
}
