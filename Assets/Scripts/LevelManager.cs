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
        Debug.Log("Reload Scene");
        GameObject.Find("GameOverPanel").GetComponent<Animator>().SetBool("show", true);
    }

    public void backToLevelSelect()
    {
        SceneManager.LoadScene("Levelselect");
        Debug.Log("Go To Levelselect");
        GameObject.Find("WonPanel").GetComponent<Animator>().SetBool("show", true);
        GameObject.Find("GameOverPanel").GetComponent<Animator>().SetBool("show", true);
    }

    public void goToNextLevel()
    {
        Debug.Log("Load next level");
        GameObject.Find("WonPanel").GetComponent<Animator>().SetBool("show", true);
    }
}
