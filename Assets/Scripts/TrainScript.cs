using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TrainScript : MonoBehaviour
{
    private Rigidbody2D train_RigidBody;
    private bool isDriving;
    private int collisionCount = 0;
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
        // If collisionCount is zero, the train is currently not on any rails -> Stop the train
        if (isDriving && collisionCount != 0)
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
        collisionCount++;
        
        // Collision with straigt rail
        if (collision.gameObject.tag.Equals("straightRail") == true) {
            // If the rotation of the rail is different than the rotation of the train -> Stop the train
            if (transform.rotation.z != collision.transform.rotation.z) {
                isDriving = false;
            }
        }
        
        // Collision with curve rail
        if (collision.gameObject.tag.Equals("curveRail") == true) {
            // If the rotation of the curve rail is different than the rotation of the train -> Stop the train 
            // There are 2 possible rotations in which the curve can be entered by the train
            // See https://discussions.unity.com/t/why-does-transform-rotate-behave-so-strange/120303
            if (transform.rotation.z != collision.transform.rotation.z && transform.rotation.eulerAngles.z != collision.transform.rotation.eulerAngles.z - 270) {
                isDriving = false;
            }
        }

        // Collision with direction changer of curveRail
        if (collision.gameObject.tag.Equals("directionChanger") == true) {
            // Depending on the side on which the train enters the curve, change direction differently
            float rotationDirection = transform.rotation.z;

            if (transform.rotation.z == collision.transform.rotation.z) {
                Debug.Log("Side A");
                rotationDirection = collision.transform.rotation.eulerAngles.z - 90;
            }

            if (transform.rotation.eulerAngles.z == collision.transform.rotation.eulerAngles.z - 270) {
                Debug.Log("Side B");
                rotationDirection = collision.transform.rotation.eulerAngles.z + 180; 
            }

            train_RigidBody.SetRotation(rotationDirection); 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionCount--;
    }
}
