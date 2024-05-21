using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey("UnlockedLevels"))
            PlayerPrefs.SetInt("UnlockedLevels", 1);
    }

    public void goToStart()
    {
        if (PlayerPrefs.HasKey("UnlockedLevels"))
            SceneManager.LoadScene("Levelmenu");
        else
            SceneManager.LoadScene("Level 1");
    }

    public void goToShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
