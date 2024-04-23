using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelselection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // MOVE INTO MAINMENU
        if (!PlayerPrefs.HasKey("stars"))
        {
            PlayerPrefs.SetInt("stars", 0);
        }
        // !!!!!!!!!!!!!!!!!!

        int stars = PlayerPrefs.GetInt("stars");
        GameObject.Find("stars").GetComponent<TextMeshProUGUI>().text = stars.ToString() + "x";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
