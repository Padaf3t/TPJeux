using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using JetBrains.Annotations;
using Newtonsoft.Json;


public class SaveSystem : MonoBehaviour
{
    private static string path;
    private void Awake()
    {
        path = Path.Combine(Application.persistentDataPath, $"game.save");
    }
    public class GameState
    {
        public int score;
        public int lives;

        public GameState(int _score, int _lives)
        {
            score = _score;
            lives = _lives;
        }
    }

    public static void SaveGame(GameState gameSave)
    {
        var serializedSave = JsonConvert.SerializeObject(gameSave);
        File.WriteAllText(path, serializedSave);
    }


    public static bool CheckHasSave()
    {

        if (File.Exists(path))
        {
            return true;

        }
        else return false;
    }


    public static GameState LoadSaveDataFromSave()
    {

        var serializedSave = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<GameState>(serializedSave);


    }
}