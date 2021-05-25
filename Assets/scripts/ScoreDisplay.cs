using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    Text scoreText;
    GameSession gameSession;
    public static int score, highScore;
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
        score = gameSession.GetScore();
        highScore = score;
    }
    void Update()
    {
        scoreText.text = gameSession.GetScore().ToString();
    }
    public void HighScore()
    {
        if (score > highScore)
            highScore = score;
    }
    public int GetHighScore()
    {
        return highScore;
    }
}
