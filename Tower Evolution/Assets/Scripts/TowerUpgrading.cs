using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrading : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    private LayerMask mask;

    private Transform selectedTower;

    void Start()
    {
        mask = LayerMask.GetMask("Tower");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
            {
                if (selectedTower != null)
                {
                    selectedTower.GetComponent<TowerPlacement>().renderers[1].enabled = false;
                }

                selectedTower = hit.transform;
                selectedTower.GetComponent<TowerPlacement>().renderers[1].enabled = true;
            }
            else
            {
                if (selectedTower != null)
                {
                    selectedTower.GetComponent<TowerPlacement>().renderers[1].enabled = false;
                }
            }
        }
    }
}