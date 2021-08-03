using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    private void Update()
    {
        scoreText.text = ScoreScript.scoreInstance.coinsText.text;
        highScoreText.text ="High score : "+ ScoreScript.scoreInstance.High.ToString();
    }
}
