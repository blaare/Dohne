using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseScreen : MonoBehaviour {

    public GameObject pauseScreen;
    public GameObject settingsScreen;

    public bool settingsScreenOpen = false;
    public void PauseGame()
    {
        Debug.Log("Player Paused");
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        MouseHider.SHOW_MOUSE();
    }

    public void ResumeGame()
    {
        
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        settingsScreen.SetActive(false);
        MouseHider.HIDE_MOUSE();
        PlayerController.gameIsPaused = false;
    }

    public void QuitGame()
    {
        if(!Application.isEditor)
            Application.Quit();
        PlayerController.gameIsPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        PlayerController.gameIsPaused = false;
    }

    public void SettingsScreen()
    {
        settingsScreen.SetActive(true);
        pauseScreen.SetActive(false);

    }

    public void ExitSettingsScreen()
    {
        settingsScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }
}
