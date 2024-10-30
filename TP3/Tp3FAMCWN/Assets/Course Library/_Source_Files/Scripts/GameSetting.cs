using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{

    public static float SoundVolume
    {
        get => PlayerPrefs.GetFloat("SoundVolume", defaultValue: 100f);
        set => PlayerPrefs.SetFloat("SoundVolume", value);
    }

    public static bool AsParticule
    {
        get => PlayerPrefs.GetInt("Particule", defaultValue: 0) >= 1;
        set => PlayerPrefs.SetInt("Particule", value == true ? 1 : 0);
    }

    public static int SpawnValue
    {
        get => PlayerPrefs.GetInt("SpawnValue", defaultValue: 1);
        set => PlayerPrefs.SetInt("SpawnValue", value);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
