using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public TrainScript trainScript;
    public GameObject pauseMenuUI;
    public GameObject WonPanel;
    public GameObject GameOverPanel;

    private LevelScript levelScript;

    void Start()
    {
        levelScript = GameObject.Find("LevelManager").GetComponent<LevelScript>();
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

    public void togglePause()
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

    public void pause()
    {
        // Pause is only possible if not Game Over and not already won
        if (WonPanel.activeSelf == false && GameOverPanel.activeSelf == false)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;

            trainScript.drivingSound.Pause();
        }
    }

    IEnumerator waiter(string scene)
    {
        WonPanel.SetActive(false);
        GameOverPanel.SetActive(false);
        levelScript.closeScene();

        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(scene);
    }

    public void retry()
    {
        resume();

        StartCoroutine(waiter(SceneManager.GetActiveScene().name));
    }

    public void backToLevelSelect()
    {
        resume();

        StartCoroutine(waiter("Levelmenu"));
    }

    public void backToMainMenu()
    {
        resume();

        StartCoroutine(waiter("Mainmenu"));
    }

    public void goToNextLevel()
    {
        int currLevel = GameObject.Find("LevelManager").GetComponent<LevelScript>().currLevel;

        // Last Level -> Go to Level Select
        if (currLevel == 25)
        {
            backToLevelSelect();
            return;
        }

        StartCoroutine(waiter("Level " + (currLevel + 1)));
    }

    public void quit()
    {
        Application.Quit();
    }
}
