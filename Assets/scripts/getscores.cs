using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class getscores : MonoBehaviour
{
    GameSession gameSession;
    Text highScoreText;
    void Start()
    {
        highScoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        highScoreText.text = gameSession.GetHighScore().ToString();
    }
}
