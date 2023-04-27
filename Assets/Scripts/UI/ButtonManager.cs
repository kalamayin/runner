using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    
    public void PlayButton()
    {
        GameController.gameState = GameState.Playing;
        CoinManager.coinTextCheck = true;
    }

    public void PauseButton()
    {
        GameController.gameState = GameState.Pause;
    }

    public void ResumeButton()
    {
        GameController.gameState = GameState.Playing;
    }

    public void NextLevel()
    {
        int buildIndex = SceneManager.GetActiveScene().buildIndex + 1;
        int totalIndex = SceneManager.sceneCountInBuildSettings;

        if(buildIndex > PlayerPrefs.GetInt("MaxLevel") && buildIndex < totalIndex - 1)PlayerPrefs.SetInt("MaxLevel", buildIndex);

        if(buildIndex < totalIndex) SceneManager.LoadScene(buildIndex);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameController.gameState = GameState.Playing;
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}
