using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        // Find all GameObjects with the tag "Target"
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("Target");

        // Create a list to hold GameObjectData for each target
        List<SaveSystem.GameObjectData> targetDataList = new List<SaveSystem.GameObjectData>();

        // For each target, create GameObjectData with position, rotation, and type
        foreach (var target in targetObjects)
        {
            // You can store any identifier for the type, e.g., use tag or some other custom field
            int type = (int)target.GetComponent<Target>().type;

            // Create GameObjectData with position and rotation
            SaveSystem.GameObjectData data = new SaveSystem.GameObjectData(
                type,
                target.transform.position,
                target.transform.rotation,
                target.GetComponent<Rigidbody>().velocity
            );

            // Add the target data to the list
            targetDataList.Add(data);
        }


        SaveSystem.GameState gs = new SaveSystem.GameState(GameManager.instance.score, GameManager.instance.nLives, targetDataList);
        SaveSystem.SaveGame(gs);
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
