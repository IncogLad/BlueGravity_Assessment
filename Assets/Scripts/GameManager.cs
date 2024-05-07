using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isPaused = false;
    
    public GameObject pauseMenu;
    private Scene currentScene;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        currentScene = SceneManager.GetActiveScene();
        
    }
    

    void Update()
    {
        if (currentScene.name == "MainMenu")
            return;


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
                isPaused = false;
            }
            else
            {
                pauseMenu.SetActive(true);
                isPaused = true;
            }
        }

    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
