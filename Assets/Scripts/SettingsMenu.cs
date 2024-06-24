using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown trainSpeedDropdown;

    void Start()
    {
        trainSpeedDropdown = GameObject.Find("TrainSpeedDropdown").GetComponent<TMPro.TMP_Dropdown>();
        trainSpeedDropdown.value = PlayerPrefs.GetInt("trainSpeed", 0);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);

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

    public void ResetPlayerprefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
