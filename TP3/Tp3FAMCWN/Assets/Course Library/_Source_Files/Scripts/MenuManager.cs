using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    public GameObject parameterMenu;
    public GameObject continueBtn;
    
    /// <summary>
    /// initialize Parameter menu and continue button visibility
    /// </summary>
    void Start()
    {
        parameterMenu.SetActive(false);
        continueBtn.SetActive(SaveSystem.CheckHasSave());

    }

    /// <summary>
    /// Click function for continue
    /// </summary>
    public void BtnContinueClick()
    {
        SceneNavigator.instance.gameState = SaveSystem.LoadSaveDataFromSave();
        SceneNavigator.OpenGame();

    }
    /// <summary>
    /// Click function for new game
    /// </summary>
    public void BtnNewGameClick()
    {
        SceneNavigator.instance.gameState = null;
        SceneNavigator.OpenGame();
    }
    /// <summary>
    /// Click function for parameter
    /// </summary>
    public void BtnParametreClick()
    {
        OpenSettings();
    }
    /// <summary>
    /// Click function for quit
    /// </summary>
    public void BtnQuitClick()
    {
        SceneNavigator.ExitApp();
    }

    /// <summary>
    /// makes the parameter visible
    /// </summary>
    public void OpenSettings()
    {
        parameterMenu.SetActive(true);
    }

}
