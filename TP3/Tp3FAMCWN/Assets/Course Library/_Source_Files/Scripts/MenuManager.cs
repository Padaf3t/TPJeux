using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject parameterMenu;
    public GameObject continueBtn;
    // Start is called before the first frame update
    void Start()
    {
        if (!SaveSystem.CheckHasSave()) { 
            continueBtn.SetActive(false);
        }
        
    }

    public void BtnContinueClick()
    {
        SaveSystem.LoadSaveDataFromSave();

    }

    public void BtnNewGameClick()
    {
        SceneNavigator.OpenGame();
    }

    public void BtnParametreClick()
    {
        Settings();
    }

    public void BtnQuitClick()
    {
       SceneNavigator.ExitApp();
    }


    public void Settings()
    {
        if (parameterMenu.activeSelf)
        {
            parameterMenu.SetActive(false);
        }
        else
        {
            parameterMenu.SetActive(true);
        }
    }
}
