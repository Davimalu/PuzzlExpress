using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuManager : MonoBehaviour
{
    public GameObject[] levels;

    // Start is called before the first frame update
    void Start()
    {
        // MOVE INTO MAINMENU
        if (!PlayerPrefs.HasKey("stars"))
        {
            PlayerPrefs.SetInt("stars", 0);
        }
        // !!!!!!!!!!!!!!!!!!

        levels[LevelSelectMenu.currLevel].SetActive(true);
    }
}
