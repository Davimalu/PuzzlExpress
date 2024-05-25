using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightRailScript : MonoBehaviour
{
    private TrainScript trainScript;
    private bool collidingWithTrain;
    public UIScript UIScript;
    public AudioSource clickSound;
    public bool isRotateable = true;

    // Start is called before the first frame update
    void Start()
    {
        trainScript = GameObject.FindGameObjectWithTag("train").GetComponent<TrainScript>();
        UIScript = GameObject.Find("Canvas").GetComponent<UIScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Debug.Log("Klick auf gerade Schiene");

        // Rotation only possible if the train is not driving, the train is not standing on that track and rail is clickable
        if (trainScript.isDriving == false && collidingWithTrain == false && UIScript.gameIsPaused == false && isRotateable == true)
        {
            // See https://discussions.unity.com/t/add-90-degrees-to-transform-rotation/31852
            Quaternion rotationDirection = transform.rotation * Quaternion.Euler(0, 0, 90);
            transform.rotation = rotationDirection;

            clickSound.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("train") == true)
        {
            collidingWithTrain = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("train") == true)
        {
            collidingWithTrain = false;
        }


    }
}