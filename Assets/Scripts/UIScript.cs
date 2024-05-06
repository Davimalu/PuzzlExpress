using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void backToLevelSelect()
    {
        SceneManager.LoadScene("Levelmenu");
    }

    public void goToNextLevel()
    {
        int currLevel = GameObject.Find("LevelManager").GetComponent<LevelScript>().currLevel;
        SceneManager.LoadScene("Level " + (currLevel + 1));
    }
}
