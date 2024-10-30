using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject pausePanel;

    public void OpenPanel()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ClosePanel()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void SaveGame()
    {
        SaveSystem.SaveGame(null);
    }

    public void ReturnToMenu()
    {
        SceneNavigator.GoToMenu();
    }

    public void QuitGame()
    {
        SceneNavigator.ExitApp();
    }
}
