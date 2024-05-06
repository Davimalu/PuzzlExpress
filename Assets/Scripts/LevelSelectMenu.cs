using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectMenu : MonoBehaviour
{
    private Button[] levelButtons;
    public Transform buttonWrapper;
    public static int UnlockedLevels;

    public void toMainMenu() {
        SceneManager.LoadScene("Mainmenu");
    }

    // Start is called before the first frame update
    void Start()
    {
        int stars = PlayerPrefs.GetInt("stars");
        GameObject.Find("stars").GetComponent<TextMeshProUGUI>().text = stars.ToString() + "x";

        int children = buttonWrapper.childCount;
        levelButtons = new Button[children];
        for (int i = 0; i < children; ++i)
        {
            levelButtons[i] = buttonWrapper.GetChild(i).GetComponent<Button>();
        }

        UnlockedLevels = PlayerPrefs.GetInt("UnlockedLevels", 0);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (UnlockedLevels >= i)
            {
                levelButtons[i].interactable = true;
            }
        }
    }
}
