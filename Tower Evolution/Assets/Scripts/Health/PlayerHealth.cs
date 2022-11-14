using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float playerHealth = 100f;
    private float totalPlayerHealth;

    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject gameStatsText;
    [SerializeField] private Button playAgain;

    private int currentWave;
    public int enemiesKilled = 0;
    public int towersPlaced = 0;

    void Start()
    {
        totalPlayerHealth = playerHealth;
        currentWave = GameObject.FindGameObjectWithTag("Spawnpoint").GetComponent<EnemySpawning>().currentWave;
    }

    void Update()
    {
        if (playerHealth <= 0)
        {
            GetComponent<RectTransform>().localScale = new Vector3(0, 1, 1);
            GameObject.Find("Health Percentage").GetComponent<TextMeshProUGUI>().text = "0%";

            gameOverScreen.SetActive(true);
            gameStatsText.GetComponent<TextMeshProUGUI>().text = $"Wave: {currentWave}\nEnemies Killed: {enemiesKilled}\nTowers Placed: {towersPlaced}";
            playAgain.Select();
            Time.timeScale = 0;
        }
        else
        {
            GetComponent<RectTransform>().localScale = new Vector3(playerHealth / totalPlayerHealth, 1, 1);
            GameObject.Find("Health Percentage").GetComponent<TextMeshProUGUI>().text = $"{playerHealth / totalPlayerHealth * 100}%";
            GetComponent<RawImage>().color = Color.Lerp(Color.red, Color.green, playerHealth / totalPlayerHealth);
        }
    }
}