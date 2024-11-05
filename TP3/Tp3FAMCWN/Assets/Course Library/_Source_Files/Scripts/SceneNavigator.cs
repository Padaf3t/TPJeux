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

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        GoToMenu();
    }

    public static void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public static void OpenGame()
    {
        SceneManager.LoadScene("Game");
    }
    public static void ExitApp()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
