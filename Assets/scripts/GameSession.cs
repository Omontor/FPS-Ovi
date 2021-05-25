using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    public static int score, highScore;
    private void Awake()
    {
        SetupSingleton();
        score = 0;
        
    }
    private void SetupSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions >1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    public int GetScore()
    {
        return score;
    }
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
        HighScore();
        
    }
    public void ResetGame()
    {
        Destroy(gameObject);
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
