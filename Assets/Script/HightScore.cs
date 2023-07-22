using System;
using UnityEngine;
using UnityEngine.UI;

public class HightScore : MonoBehaviour
{
    public int score;
    public int highScore;
    public Text HighScoreText;

    private void Start()
    {
        score = ScoreManager.score;
        highScore = PlayerPrefs.GetInt("highScore", 0);
        HighScoreText.text = highScore.ToString();
        HighScore();
    }

    public void HighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("highScore", highScore);
        }
        HighScoreText.text = highScore.ToString();
    }

}
