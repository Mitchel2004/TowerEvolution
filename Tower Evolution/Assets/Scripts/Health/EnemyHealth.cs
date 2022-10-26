using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;
    public int totalEnemyHealth;

    [SerializeField] private int killEarnings;

    void Start()
    {
        totalEnemyHealth = enemyHealth;
    }

    void Update()
    {
        GetComponent<TextMesh>().text = enemyHealth.ToString();

        transform.rotation = Camera.main.transform.rotation;

        if (enemyHealth <= 0)
        {
            enemyHealth = totalEnemyHealth;
            GameObject.Find("Money").GetComponent<MoneyHandler>().money += killEarnings;
            GetComponentInParent<EnemyMovement>().index = 0;
            transform.parent.gameObject.SetActive(false);
        }
    }
}