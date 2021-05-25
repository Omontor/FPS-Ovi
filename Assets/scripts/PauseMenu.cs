using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausemenu;
    public static bool isPaused;
    SceneLoader sceneLoader;
    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResumeGame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void PauseGame()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void MainMenu()
    {
        sceneLoader.LoadMainScene();
    }
    public void QuitGame()
    {
        sceneLoader.QuitGame();
    }
}
