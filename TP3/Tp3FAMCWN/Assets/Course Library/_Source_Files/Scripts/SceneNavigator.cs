using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SaveSystem;

public class SceneNavigator : MonoBehaviour
{
    public static SceneNavigator instance;

    public GameState gameState;

    /// <summary>
    /// initialize Scene Navigator
    /// </summary>
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GoToMenu();
    }

    /// <summary>
    /// Go to menu opens the menu scene
    /// </summary>
    public static void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    /// <summary>
    /// Open Game opens the Game Scene
    /// </summary>
    public static void OpenGame()
    {
        SceneManager.LoadScene("Game");
    }
    /// <summary>
    /// Closes app 
    /// </summary>
    public static void ExitApp()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
