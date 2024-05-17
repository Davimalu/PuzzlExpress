using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public TrainScript trainScript;
    public GameObject pauseMenuUI;

    void Start()
    {
        trainScript = GameObject.Find("Train").GetComponent<TrainScript>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

        if (trainScript.isDriving == true)
        {
            trainScript.drivingSound.Play();
        }
    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

        trainScript.drivingSound.Pause();
    }

    public void retry()
    {
        resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void backToLevelSelect()
    {
        resume();
        SceneManager.LoadScene("Levelmenu");
    }

    public void backToMainMenu()
    {
        resume();
        SceneManager.LoadScene("Mainmenu");
    }

    public void goToNextLevel()
    {
        int currLevel = GameObject.Find("LevelManager").GetComponent<LevelScript>().currLevel;
        SceneManager.LoadScene("Level " + (currLevel + 1));
    }

    public void quit()
    {
        Application.Quit();
    }
}
