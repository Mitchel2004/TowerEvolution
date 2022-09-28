using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerSpawning : MonoBehaviour
{
    [SerializeField] private GameObject tower;
    private GameObject instantiatedTower;

    private int price;

    void Start()
    {
        price = GetComponentInChildren<TowerPriceHandler>().price;
    }

    void Update()
    {
        if (GameObject.Find("Money").GetComponent<MoneyHandler>().money < price)
        {
            GetComponent<Button>().interactable = false;
        }
        else
        {
            GetComponent<Button>().interactable = true;
        }
    }

    public void SpawnTower()
    {
        instantiatedTower = Instantiate(tower);

        instantiatedTower.GetComponent<TowerPlacement>().price = price;
    }
}