using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using JetBrains.Annotations;
using Newtonsoft.Json;

public class SaveSystem : MonoBehaviour
{
    
    public class GameSave
    {
        public int score;
        public int lives;
    }

    public static void SaveGame(GameSave gameSave)
    {
        var serializedSave = JsonConvert.SerializeObject(gameSave);

        var path = Path.Combine(Application.persistentDataPath, $"game.save");
    }



}
