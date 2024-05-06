using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void backToLevelSelect()
    {   
        GameObject.Find("WonPanel").GetComponent<Animator>().SetBool("show", false);
        GameObject.Find("GameOverPanel").GetComponent<Animator>().SetBool("show", false);
        SceneManager.LoadScene("LevelSelectMenuScene");
    }

    public void goToNextLevel()
    {
        GameObject.Find("WonPanel").GetComponent<Animator>().SetBool("show", false);
    }
}
