using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    private Collider gameRange;
    [SerializeField] private Material towerRangeCircle;

    private Vector3 mousePosition;
    private Vector3 placePosition;

    private bool rendererEnabled = false;

    public Renderer[] renderers;
    private List<Collider> colliders = new List<Collider>();

    private bool isInGameRange = false;
    private bool canPlace = true;

    [SerializeField] public int damage;

    public int price;

    void Start()
    {
        gameRange = GameObject.Find("Game Range").GetComponent<Collider>();
        renderers = GetComponentsInChildren<Renderer>();
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        placePosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.y - GetComponent<Renderer>().bounds.extents.y));

        transform.position = placePosition;

        if (!rendererEnabled)
        {
            rendererEnabled = true;

            foreach (Renderer renderer in renderers)
            {
                renderer.enabled = true;
            }
        }

        if (Input.GetMouseButtonUp(0) && isInGameRange && canPlace)
        {
            tag = "Tower";
            GetComponent<BoxCollider>().isTrigger = true;
            GameObject.Find("Money").GetComponent<MoneyHandler>().money -= price;
            GameObject.Find("Health Bar").GetComponent<PlayerHealth>().towersPlaced += 1;
            GetComponentInChildren<ProjectileSpawning>().enabled = true;
            renderers[1].enabled = false;
            GetComponent<TowerUpgrading>().enabled = true;
            GetComponent<TowerPlacement>().enabled = false;
        }

        if (Input.GetMouseButtonUp(1))
        {
            towerRangeCircle.color = Color.white;
            Destroy(gameObject);
        }
        else if (colliders.Count == 0 && isInGameRange)
        {
            canPlace = true;
            towerRangeCircle.color = Color.white;
        }
        else
        {
            canPlace = false;
            towerRangeCircle.color = Color.red;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == gameRange)
        {
            isInGameRange = true;
        }

        if (other.CompareTag("Tower") || other.CompareTag("Enemy") || other.CompareTag("Path"))
        {
            colliders.Add(other);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other == gameRange)
        {
            isInGameRange = false;
        }

        if (other.CompareTag("Tower") || other.CompareTag("Enemy") || other.CompareTag("Path"))
        {
            colliders.Remove(other);
        }
    }
}