using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class LevelScript : MonoBehaviour
{
    public int currLevel;
    public GameObject starPrefab;

    public Vector3[] starPositions;

    void Start()
    {
        string stars = PlayerPrefs.GetString("Level" + currLevel);

        string[] starIds = stars.Split(',');

        for (int i = 0; i < starPositions.Length; i++)
        {
            Vector3 pos = starPositions[i];
            if (Array.IndexOf(starIds, (i + 1).ToString()) == -1)
            {
                var newStar = Instantiate(starPrefab, new Vector3(pos.x, pos.y), Quaternion.identity);
                newStar.name = (i + 1).ToString();
            }
        }
    }
}
