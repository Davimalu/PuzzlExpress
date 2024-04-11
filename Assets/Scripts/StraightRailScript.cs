using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightRailScript : MonoBehaviour
{
    private TrainScript trainScript;

    // Start is called before the first frame update
    void Start()
    {
        trainScript = GameObject.FindGameObjectWithTag("train").GetComponent<TrainScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Debug.Log("Klick auf gerade Schiene");

        // Rotation only possible if the train is not driving
        if (trainScript.isDriving == false)
        {
            // See https://discussions.unity.com/t/add-90-degrees-to-transform-rotation/31852
            Quaternion rotationDirection = transform.rotation * Quaternion.Euler(0, 0, 90);
            transform.rotation = rotationDirection;
        }
    }
}
