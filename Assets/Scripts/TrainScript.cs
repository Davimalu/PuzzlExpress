using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TrainScript : MonoBehaviour
{
    private Rigidbody2D train_RigidBody;
    private bool isDriving;
    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        // Get RigidBody Component
        train_RigidBody = GetComponent<Rigidbody2D>();
        
        isDriving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDriving)
        {
            // Always move the train forward in the direction it is facing

            // See https://discussions.unity.com/t/transform-forward-in-2d/182904
            Vector2 direction = -transform.right;
            train_RigidBody.MovePosition(train_RigidBody.position + direction * Time.deltaTime * speed);     
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("klick auf Zug");
        isDriving = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the rotation of the rail is different than the rotation of the train -> Stop the train
        if (transform.rotation.z != collision.transform.rotation.z) {
            isDriving = false;
        }
    }
}
