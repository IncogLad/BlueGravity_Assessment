using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadSceneAsync("GameScene");
    }

    public void ReturnToGame()
    {
        gameObject.SetActive(false);
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
