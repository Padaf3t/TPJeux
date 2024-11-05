using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameSettingsPanel : MonoBehaviour
{
    public GameObject parameterMenu;
    public Slider audioSlider;
    public Slider spawnRateSlider;
    public Toggle particleToggle;

    void Start()
    {
        audioSlider.SetValueWithoutNotify(GameSetting.SoundVolume);
        spawnRateSlider.SetValueWithoutNotify(GameSetting.SpawnValue);
        particleToggle.SetValueWithoutNotify(GameSetting.HasParticule);


    }


    public void AudioSlider(float volume)
    {
        GameSetting.SoundVolume = volume;
    }
    public void SpawnRateSlider(float spawnRate)
    {
        GameSetting.SpawnValue = spawnRate;
    }

    public void ParticleToggle(bool toggle)
    {
        GameSetting.HasParticule = toggle;
    }

    public void CloseSettings()
    {
        parameterMenu.SetActive(false);
    }
}
