using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public TMPro.TMP_Dropdown trainSpeedDropdown;
    public TMPro.TMP_Dropdown resolutionDropdown;
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        trainSpeedDropdown = GameObject.Find("TrainSpeedDropdown").GetComponent<TMPro.TMP_Dropdown>();
        trainSpeedDropdown.value = PlayerPrefs.GetInt("trainSpeed", 0);

        resolutionDropdown = GameObject.Find("ResolutionDropdown").GetComponent<TMPro.TMP_Dropdown>();
        resolutionDropdown.value = PlayerPrefs.GetInt("resolution", 0);

        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void SetVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void setTrainSpeed(int speed)
    {
        PlayerPrefs.SetInt("trainSpeed", speed);
    }

    public void setResolution(int resolution)
    {
        switch (resolution)
        {
            case 0:
                Screen.SetResolution(1920, 1080, Screen.fullScreen);
                break;
            case 1:
                Screen.SetResolution(1366, 768, Screen.fullScreen);
                break;
            case 2:
                Screen.SetResolution(1280, 720, Screen.fullScreen);
                break;
        }

        PlayerPrefs.SetInt("resolution", resolution);
    }

    public void ResetPlayerprefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
