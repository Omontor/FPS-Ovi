using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class getscores : MonoBehaviour
{
    GameSession gameSession;
    Text highScoreText;
    public int highScore;
    public float playerPrefHighScore;
    void Start()
    {
        
        highScoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
        highScore = gameSession.GetHighScore();
        playerPrefHighScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("playerPrefHighScore")<=highScore)
        {
            PlayerPrefs.SetInt("playerPrefHighScore", highScore);
        }
        highScoreText.text = PlayerPrefs.GetInt("playerPrefHighScore").ToString();
    }
}
