using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteScript : MonoBehaviour
{

    public void OnLevelComplete()
    {
        if(LevelSelectMenu.currLevel == LevelSelectMenu.UnlockedLevels)
        {
            LevelSelectMenu.UnlockedLevels++;
            PlayerPrefs.SetInt("UnlockedLevels", LevelSelectMenu.UnlockedLevels);
        }
        SceneManager.LoadScene("SampleScene");
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
