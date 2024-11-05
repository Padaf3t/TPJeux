using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject pausePanel;

    /// <summary>
    /// Open the pause panel
    /// </summary>
    public void OpenPanel()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    /// <summary>
    /// Close the pause panel
    /// </summary>
    public void ClosePanel()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    /// <summary>
    /// Save the state of the game
    /// </summary>
    public void SaveGame()
    {
        // Find all GameObjects with the tag "Target"
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("Target");

        // Create a list to hold GameObjectData for each target
        List<SaveSystem.GameObjectData> targetDataList = new List<SaveSystem.GameObjectData>();

        // For each target, create GameObjectData with position, rotation, velocity and type
        foreach (var target in targetObjects)
        {
            int type = target.GetComponent<Target>().typeIndex;
            SaveSystem.GameObjectData data = new SaveSystem.GameObjectData(
                type,
                target.transform.position,
                target.transform.rotation,
                target.GetComponent<Rigidbody>().velocity
            );
            targetDataList.Add(data);
        }

        SaveSystem.GameState gs = new SaveSystem.GameState(GameManager.instance.score, GameManager.instance.nLives, targetDataList);
        SaveSystem.SaveGame(gs);
    }

    /// <summary>
    /// Return to the main menu
    /// </summary>
    public void ReturnToMenu()
    {
        SceneNavigator.GoToMenu();
    }

    /// <summary>
    /// Quit the game
    /// </summary>
    public void QuitGame()
    {
        SceneNavigator.ExitApp();
    }
}
