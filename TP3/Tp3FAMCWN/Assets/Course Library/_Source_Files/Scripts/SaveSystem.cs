using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using JetBrains.Annotations;
using Newtonsoft.Json;


public class SaveSystem : MonoBehaviour
{
    /// <summary>
    /// Attribute for the save location
    /// </summary>
    private static string path;
    /// <summary>
    /// Call game save path on awake
    /// </summary>
    private void Awake()
    {
        path = Path.Combine(Application.persistentDataPath, $"game.save");
    }
    /// <summary>
    /// Class gameState to register save related information
    /// </summary>
    public class GameState
    {
        public int score;
        public int lives;
        public List<GameObjectData> targetData;
        /// <summary>
        /// GameState constructor
        /// </summary>
        /// <param name="_score"></param>
        /// <param name="_lives"></param>
        /// <param name="_targetData"></param>
        public GameState(int _score, int _lives, List<GameObjectData> _targetData)
        {
            score = _score;
            lives = _lives;
            targetData = _targetData;
        }
    }

    /// <summary>
    /// Class that contains relevant info for the different objects in the scene
    /// </summary>
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

        /// <summary>
        /// class constructor
        /// </summary>
        /// <param name="_type"></param>
        /// <param name="_position"></param>
        /// <param name="_rotation"></param>
        /// <param name="_velocity"></param>
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

    /// <summary>
    /// Save game method that writes the info to a json file
    /// </summary>
    /// <param name="gameSave"></param>
    public static void SaveGame(GameState gameSave)
    {
        var serializedSave = JsonConvert.SerializeObject(gameSave);
        File.WriteAllText(path, serializedSave);
    }

    /// <summary>
    /// Checks if the game has an already existing game file
    /// </summary>
    /// <returns></returns>
    public static bool CheckHasSave()
    {

        if (File.Exists(path))
        {
            return true;

        }
        else return false;
    }

    /// <summary>
    /// Read JSON file 
    /// </summary>
    /// <returns></returns>
    public static GameState LoadSaveDataFromSave()
    {

        var serializedSave = File.ReadAllText(path);
        return JsonConvert.DeserializeObject<GameState>(serializedSave);


    }
}