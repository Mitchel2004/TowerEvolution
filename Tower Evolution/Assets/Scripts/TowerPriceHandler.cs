using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerPriceHandler : MonoBehaviour
{
    [SerializeField] private GameObject tower;

    private int damage;
    public int price;
    [SerializeField] private int priceMultiplier = 100;

    void Start()
    {
        damage = tower.GetComponent<TowerPlacement>().damage;

        price = damage * priceMultiplier;

        GetComponent<TextMeshProUGUI>().text = price.ToString();
    }
}