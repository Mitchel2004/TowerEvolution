using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyHandler : MonoBehaviour
{
    public int money = 250;

    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = money.ToString();
    }
}