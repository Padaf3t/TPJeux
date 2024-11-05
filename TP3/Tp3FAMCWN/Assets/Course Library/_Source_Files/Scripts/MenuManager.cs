using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    public GameObject parameterMenu;
    public GameObject continueBtn;
    
    // Start is called before the first frame update
    void Start()
    {
        parameterMenu.SetActive(false);
        if (!SaveSystem.CheckHasSave())
        {
            continueBtn.SetActive(false);
        }

    }

    public void BtnContinueClick()
    {
        SceneNavigator.instance.gameState = SaveSystem.LoadSaveDataFromSave();
        SceneNavigator.OpenGame();

    }

    public void BtnNewGameClick()
    {
        SceneNavigator.instance.gameState = null;
        SceneNavigator.OpenGame();
    }

    public void BtnParametreClick()
    {
        OpenSettings();
    }

    public void BtnQuitClick()
    {
        SceneNavigator.ExitApp();
    }


    public void OpenSettings()
    {
        parameterMenu.SetActive(true);
    }

}
