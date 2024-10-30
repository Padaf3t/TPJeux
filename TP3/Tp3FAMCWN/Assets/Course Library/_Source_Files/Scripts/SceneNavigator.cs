using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    private void Start()
    {
        GoToMenu();
    }

    private static void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    private static void OpenGame()
    {
        SceneManager.LoadScene("Game");
    }
    private static void ExitApp()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
