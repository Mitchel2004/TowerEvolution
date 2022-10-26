using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float playerHealth = 100f;
    private float totalPlayerHealth;

    void Start()
    {
        totalPlayerHealth = playerHealth;
    }

    void Update()
    {
        if (playerHealth <= 0)
        {
            GetComponent<RectTransform>().localScale = new Vector3(0, 1, 1);
            GameObject.Find("Health Percentage").GetComponent<TextMeshProUGUI>().text = "0%";
            Debug.Log("Game Over");
        }
        else
        {
            GetComponent<RectTransform>().localScale = new Vector3(playerHealth / totalPlayerHealth, 1, 1);
            GameObject.Find("Health Percentage").GetComponent<TextMeshProUGUI>().text = $"{playerHealth / totalPlayerHealth * 100}%";
            GetComponent<RawImage>().color = Color.Lerp(Color.red, Color.green, playerHealth / totalPlayerHealth);
        }
    }
}