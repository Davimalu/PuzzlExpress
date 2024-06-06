using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume (float volume)
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

    public void ResetPlayerprefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
