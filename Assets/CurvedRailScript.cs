using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurvedRailScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Debug.Log("Klick auf Kurve");

        // See https://discussions.unity.com/t/add-90-degrees-to-transform-rotation/31852
        Quaternion rotationDirection = transform.rotation * Quaternion.Euler(0, 0, 90);
        transform.rotation = rotationDirection;
    }
}
