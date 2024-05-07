using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool isPaused = false;
    
    public GameObject pauseMenu;
    public GameObject inventoryPanel;
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!inventoryPanel.activeSelf && !pauseMenu.activeSelf)
            {
                inventoryPanel.SetActive(true);
            }
            else
            {
                inventoryPanel.SetActive(false);
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
