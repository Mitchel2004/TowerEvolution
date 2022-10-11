using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class TowerSpawning : MonoBehaviour
{
    [SerializeField] private GameObject tower;
    private GameObject instantiatedTower;

    private int damage;
    private int price;
    [SerializeField] private int priceMultiplier = 100;

    void Start()
    {
        damage = tower.GetComponentInChildren<TowerPlacement>().damage;

        price = damage * priceMultiplier;

        GetComponentInChildren<TextMeshProUGUI>().text = price.ToString();
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
        Destroy(GameObject.FindGameObjectWithTag("Unspawned Tower"));

        instantiatedTower = Instantiate(tower);

        instantiatedTower.GetComponentInChildren<TowerPlacement>().price = price;
    }
}