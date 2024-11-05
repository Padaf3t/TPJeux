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
        public List<GameObjectData> targetData;

        public GameState(int _score, int _lives, List<GameObjectData> _targetData)
        {
            score = _score;
            lives = _lives;
            targetData = _targetData;
        }
    }

    [System.Serializable]
    public class GameObjectData
    {
        public int type;

        public float xPosition;
        public float yPosition;
        public float zPosition;

        public float xAngle;
        public float yAngle;
        public float zAngle;

        public float xVelocity;
        public float yVelocity;
        public float zVelocity;

        public GameObjectData(int _type, Vector3 _position, Quaternion _rotation, Vector3 _velocity)
        {
            type = _type;

            xPosition = _position.x;
            yPosition = _position.y;
            zPosition = _position.z;

            xAngle = _rotation.eulerAngles.x;
            yAngle = _rotation.eulerAngles.y;
            zAngle = _rotation.eulerAngles.z;

            xVelocity = _velocity.x;
            yVelocity = _velocity.y;
            zVelocity = _velocity.z;
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