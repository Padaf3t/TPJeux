using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettingsPanel : MonoBehaviour
{
    public GameObject parameterMenu;
    public Slider audioSlider;
    public Slider spawnRateSlider;
    public Toggle particleToggle;

    /// <summary>
    /// initialize slider and toggle values to default values
    /// </summary>
    void Start()
    {
        audioSlider.SetValueWithoutNotify(GameSetting.SoundVolume);
        spawnRateSlider.SetValueWithoutNotify(GameSetting.SpawnValue);
        particleToggle.SetIsOnWithoutNotify(GameSetting.HasParticule);
    }

    /// <summary>
    /// function for audio slider use
    /// </summary>
    /// <param name="volume"></param>
    public void AudioSlider(float volume)
    {
        GameSetting.SoundVolume = volume;
    }
    /// <summary>
    /// function for spawn rate slider use
    /// </summary>
    /// <param name="spawnRate"></param>
    public void SpawnRateSlider(float spawnRate)
    {
        GameSetting.SpawnValue = spawnRate;
    }
    /// <summary>
    /// function for particle toggle use
    /// </summary>
    /// <param name="toggle"></param>
    public void ParticleToggle(bool toggle)
    {
        GameSetting.HasParticule = toggle;
    }
    /// <summary>
    /// function for the exit button
    /// </summary>
    public void CloseSettings()
    {
        parameterMenu.SetActive(false);
    }
}
