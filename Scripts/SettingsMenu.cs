using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public Slider musicSlider;
    public TMP_Text musicValueText;

    public Slider sfxSlider;
    public TMP_Text sfxValueText;

    void OnEnable()
    {
        if (AudioManager.instance == null) return;

        float music = PlayerPrefs.GetFloat("MusicVolume", 1f) * 100f;
        float sfx = PlayerPrefs.GetFloat("SFXVolume", 1f) * 100f;

        musicSlider.SetValueWithoutNotify(music);
        sfxSlider.SetValueWithoutNotify(sfx);

        UpdateMusic(music);
        UpdateSFX(sfx);
    }

    public void UpdateMusic(float value)
    {
        

        musicValueText.text = value.ToString("0");

        if (AudioManager.instance == null)
        {
            Debug.LogError("AudioManager instance is NULL");
            return;
        }

        AudioManager.instance.SetMusicVolume(value / 100f);

        Debug.Log($"Music slider value: {value / 100f}");
    }

    public void UpdateSFX(float value)
    {
       

        sfxValueText.text = value.ToString("0");

        if (AudioManager.instance == null)
        {
            Debug.LogError("AudioManager instance is NULL");
            return;
        }

        AudioManager.instance.SetSFXVolume(value / 100f);
        Debug.Log($"SFX slider value: {value / 100f}");
    }

}
