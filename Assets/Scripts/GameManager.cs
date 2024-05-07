using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    private GameObject pauseMenu;
    private GameObject inventoryPanel;

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
    }

    void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>().gameObject;
        inventoryPanel = FindObjectOfType<InventoryManager>().gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
            }
            else
            {
                pauseMenu.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(true);
            }
            else
            {
                inventoryPanel.SetActive(false);
            }
        }
    }

    void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    void ExitGame()
    {
        Application.Quit();
    }


}
