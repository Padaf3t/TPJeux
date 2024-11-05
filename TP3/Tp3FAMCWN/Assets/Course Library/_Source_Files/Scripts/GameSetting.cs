using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    public static float SoundVolume
    {
        get => PlayerPrefs.GetFloat("SoundVolume", defaultValue: 1f);
        set => PlayerPrefs.SetFloat("SoundVolume", value);
    }

    public static bool HasParticule
    {
        get => PlayerPrefs.GetInt("Particule", defaultValue: 0) >= 1;
        set => PlayerPrefs.SetInt("Particule", value == true ? 1 : 0);
    }

    public static float SpawnValue
    {
        get => PlayerPrefs.GetFloat("SpawnValue", defaultValue: 1);
        set => PlayerPrefs.SetFloat("SpawnValue", value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
