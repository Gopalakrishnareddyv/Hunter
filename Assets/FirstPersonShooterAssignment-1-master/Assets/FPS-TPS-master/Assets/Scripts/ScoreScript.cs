using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{
    public int coins;
    int enemies;
    int highScore=0;
    public int High;
    public Text coinsText;
    public Text enemiesText;
    bool coinCount;
    bool enemyCount;
    public static ScoreScript scoreInstance;
    private void Awake()
    {
        scoreInstance = this;
    }
    public void CoinIncrement()
    {
        coins++;
        coinsText.text = "Coins : " + coins;
        if (coins == 10)
        {
            coinCount = true;
        }
        if (coins > highScore)
        {
            High = coins;
            highScore = coins;
        }
        else
        {
            High = highScore;
        }
    }
    public void EnemyIncrement()
    {
        enemies++;
        enemiesText.text = "Enemies : " + enemies;
        if (enemies == 3)
        {
            enemyCount = true;
            PlayerData.Instance.SetData();
            PlayerData.Instance.GetData();
        }
    }
    private void Update()
    {
        if (coinCount && enemyCount)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

}
