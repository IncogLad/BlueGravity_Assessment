using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadSceneAsync("GameScene");
        gameObject.SetActive(false);
        GameManager.Instance.isPaused = false;
    }

    public void ReturnToGame()
    {
        gameObject.SetActive(false);
        GameManager.Instance.isPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
        gameObject.SetActive(false);
        GameManager.Instance.isPaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
