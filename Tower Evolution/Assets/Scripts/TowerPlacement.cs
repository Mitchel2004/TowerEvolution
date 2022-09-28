using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerPlacement : MonoBehaviour
{
    private Collider gameRange;

    private Vector3 mousePosition;
    private Vector3 placePosition;

    private bool isInGame = false;
    private bool rendererEnabled = false;
    private bool isInGameRange = false;
    private bool canPlace = true;

    [SerializeField] public int damage;

    public int price;

    void Start()
    {
        gameRange = GameObject.Find("Game Range").GetComponent<Collider>();
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        placePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y - GetComponent<Renderer>().bounds.extents.y));

        transform.position = placePosition;
        isInGame = true;

        if (isInGame && !rendererEnabled)
        {
            rendererEnabled = true;
            GetComponent<Renderer>().enabled = true;
        }

        if (Input.GetMouseButtonUp(0) && isInGameRange)
        {
            if (canPlace)
            {
                GetComponent<BoxCollider>().isTrigger = true;
                tag = "Tower";
                GameObject.Find("Money").GetComponent<MoneyHandler>().money -= price;
                GetComponent<TowerPlacement>().enabled = false;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        if (Input.GetMouseButtonUp(1))
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == gameRange)
        {
            isInGameRange = true;
        }
        
        if (isInGameRange)
        {
            if (other == other.CompareTag("Tower") || other == other.CompareTag("Enemy") || other == other.CompareTag("Path"))
            {
                GetComponent<Renderer>().enabled = false;
                canPlace = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == gameRange)
        {
            isInGameRange = false;
        }

        if (isInGameRange)
        {
            if (other == other.CompareTag("Tower") || other == other.CompareTag("Enemy") || other == other.CompareTag("Path"))
            {
                GetComponent<Renderer>().enabled = true;
                canPlace = true;
            }
        }
    }
}