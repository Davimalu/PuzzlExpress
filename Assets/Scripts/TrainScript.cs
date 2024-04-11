using System;
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
        // See https://discussions.unity.com/t/why-does-transform-rotate-behave-so-strange/120303
        double trainRotation = Mathf.Round(transform.rotation.eulerAngles.z) % 360;
        double colliderRotation = Mathf.Round(collision.transform.rotation.eulerAngles.z) % 360;

        collisionCount++;

        // Collision with straigt rail
        if (collision.gameObject.tag.Equals("straightRail") == true)
        {
            // If the rotation of the rail is different than the rotation of the train -> Stop the train
            // Distinguish whether the train is travelling horizontally or vertically

            if (trainRotation != colliderRotation && trainRotation != colliderRotation - 180 && trainRotation != colliderRotation + 180)
            {
                Debug.Log("Stop A");
                Debug.Log(trainRotation);
                Debug.Log(colliderRotation);
                isDriving = false;
            }
        }

        // Collision with curve rail
        if (collision.gameObject.tag.Equals("curveRail") == true)
        {
            // If the rotation of the curve rail is different than the rotation of the train -> Stop the train 
            // Distinguish whether the train is travelling horizontally or vertically

            if (trainRotation != colliderRotation && trainRotation != colliderRotation - 270 && trainRotation != colliderRotation + 90)
            {
                Debug.Log("Stop C");
                Debug.Log(trainRotation);
                Debug.Log(colliderRotation);
                isDriving = false;
            }
        }

        // Collision with direction changer of curveRail
        /* Note: The child of Train (Center Collider) and Curve Rail (Direction Changer) are both on a different layer (curveCollider)
           This ensures that the middle of the train will collide with the middle of the curve */
        if (collision.gameObject.tag.Equals("directionChanger") == true)
        {
            // Distinguish whether the train is travelling horizontally or vertically
            // Depending on the side on which the train enters the curve, change direction differently
            Quaternion rotationDirection = Quaternion.Euler(0, 0, 0);

            if (trainRotation == 0 || trainRotation == 180)
            {
                if (trainRotation == colliderRotation)
                {
                    // Note: Use quaternions instead of degrees to avoid floating point inaccuracies
                    if (trainRotation == 0)
                    {
                        Debug.Log("A");
                        rotationDirection = Quaternion.Euler(0, 0, 270);
                    }
                    else if (trainRotation == 180)
                    {
                        Debug.Log("B");
                        rotationDirection = Quaternion.Euler(0, 0, 90);
                    }
                }

                if (trainRotation == colliderRotation + 90)
                {
                    rotationDirection = Quaternion.Euler(0, 0, 270);
                }

                Debug.Log(colliderRotation);
                Debug.Log(trainRotation);

                if (trainRotation == colliderRotation - 270)
                {
                    rotationDirection = Quaternion.Euler(0, 0, 90);
                }
            }
            else
            {
                if (trainRotation == colliderRotation)
                {
                    if (trainRotation == 90)
                    {
                        rotationDirection = Quaternion.Euler(0, 0, 0);
                    }
                    if (trainRotation == 270)
                    {
                        rotationDirection = Quaternion.Euler(0, 0, 180);
                    }
                }

                if (trainRotation == colliderRotation - 270 || trainRotation == colliderRotation + 90)
                {
                    if (trainRotation == 90)
                    {
                        rotationDirection = Quaternion.Euler(0, 0, 180);
                    }
                    if (trainRotation == -90)
                    {
                        rotationDirection = Quaternion.Euler(0, 0, 0);
                    }
                }
            }

            transform.rotation = rotationDirection;
            // train_RigidBody.SetRotation(rotationDirection);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionCount--;
    }
}
