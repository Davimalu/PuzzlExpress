using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TrainScript : MonoBehaviour
{
    private bool isDriving;
    public float speed;

    public Transform target;
    

    // Start is called before the first frame update
    void Start()
    {
        isDriving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDriving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
            
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("klick auf Zug");
        isDriving = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        target = collision.transform;
        if (transform.rotation.z != collision.transform.rotation.z) {
            isDriving = false;
        }
    }
}
