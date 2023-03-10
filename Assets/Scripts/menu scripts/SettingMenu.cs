using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;
using SojaExiles;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropDown;
    public TextMeshProUGUI musicVolumeText;
    public TextMeshProUGUI soundEffectVolumeText;
    public TextMeshProUGUI mouseSensetivityText;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();

        float volume;
        audioMixer.GetFloat("MusicVolume", out volume);
        GameObject.Find("MusicSlider").GetComponent<Slider>().value = Mathf.RoundToInt((volume + 80f) / 0.8f);
        audioMixer.GetFloat("SoundEffectVolume", out volume);
        GameObject.Find("EffectSlider").GetComponent<Slider>().value = Mathf.RoundToInt((volume + 80f) / 0.9f);
        GameObject.Find("MouseSlider").GetComponent<Slider>().value = Mathf.RoundToInt((MouseLook.mouseXSensitivity - 100f) / 9f);

        musicVolumeText.text = GameObject.Find("MusicSlider").GetComponent<Slider>().value.ToString();
        soundEffectVolumeText.text = GameObject.Find("EffectSlider").GetComponent<Slider>().value.ToString();
        mouseSensetivityText.text = GameObject.Find("MouseSlider").GetComponent<Slider>().value.ToString();
    }
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", 0.8f * volume - 80f);
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", 0.8f * volume - 80f);
        musicVolumeText.text = $"{(int)volume}";
    }
    public void SetSoundEffectVolume(float volume)
    {
        audioMixer.SetFloat("SoundEffectVolume", 0.9f * volume - 80f);
        soundEffectVolumeText.text = $"{(int)volume}";
    }
    public void SetMouseSensetivityVolume(float volume)
    {
        MouseLook.mouseXSensitivity = 9f * volume + 100f;
        mouseSensetivityText.text = $"{(int)volume}";
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
