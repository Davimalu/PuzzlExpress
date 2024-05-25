using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (TriggerTutorial());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TriggerTutorial()
    {
        yield return new WaitForSeconds(0.6f);
        foreach (Transform child in transform)
        {
            if (child.name == "teacher" || child.name == "SpeechBox") {
                child.gameObject.SetActive(true);
            }
        }
    }
}