using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TrainScript : MonoBehaviour
{
    private Rigidbody2D train_RigidBody;
    public bool isDriving;
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

        if (collision.gameObject.tag.Equals("trainStation") == true)
        {
            GameObject.Find("Panel").GetComponent<Animator>().SetBool("show", true);
        }

        if (collision.gameObject.tag.Equals("stationEnd") == true)
        {
            isDriving = false;
        }

        // Collision with straigt rail
        if (collision.gameObject.tag.Equals("straightRail") == true)
        {
            // If the rotation of the rail is too different from the rotation of the train -> Stop the train

            // Train travelling from right to left
            if (trainRotation < 45 || trainRotation > 315) {
                if(colliderRotation != 0 && colliderRotation != 180) {
                    Debug.Log("Stop A");
                    isDriving = false;
                }
            }

            // Train travelling from left to right
            if (trainRotation > 135 && trainRotation < 225) {
                if(colliderRotation != 0 && colliderRotation != 180) {
                    Debug.Log("Stop B");
                    isDriving = false;
                }
            }

            // Train travelling from top to bottom
            if (trainRotation > 45 && trainRotation < 135) {
                if(colliderRotation != 90 && colliderRotation != 270) {
                    Debug.Log("Stop C");
                    isDriving = false;
                }
            }

            // Train travelling from bottom to top
            if (trainRotation > 225 && trainRotation < 315) {
                if(colliderRotation != 90 && colliderRotation != 270) {
                    Debug.Log("Stop D");
                    isDriving = false;
                }
            }
        }

        // Collision with curve rail
        if (collision.gameObject.tag.Equals("curveRail") == true)
        {
            // If the rotation of the curve rail is too different than the rotation of the train -> Stop the train 

            // Train travelling from right to left
            if (trainRotation < 45 || trainRotation > 315) {
                if(colliderRotation != 0 && colliderRotation != 270) {
                    Debug.Log("Stop E");
                    isDriving = false;
                }
            }

            // Train travelling from left to right
            if (trainRotation > 135 && trainRotation < 225) {
                if(colliderRotation != 90 && colliderRotation != 180) {
                    Debug.Log("Stop F");
                    isDriving = false;
                }
            }

            // Train travelling from top to bottom
            if (trainRotation > 45 && trainRotation < 135) {
                if(colliderRotation != 0 && colliderRotation != 90) {
                    Debug.Log("Stop G");
                    isDriving = false;
                }
            }

            // Train travelling from bottom to top
            if (trainRotation > 225 && trainRotation < 315) {
                if(colliderRotation != 180 && colliderRotation != 270) {
                    Debug.Log("Stop H");
                    isDriving = false;
                }
            }

        }

        // Collision with direction changer of curveRail
        /* Note: The child of Train (Center Collider) and Curve Rail (Direction Changer) are both on a different layer (curveCollider)
           This ensures that the middle of the train will collide with the middle of the curve */
        if (collision.gameObject.tag.Equals("directionChanger") == true)
        {
            Quaternion rotationDirection = Quaternion.Euler(0, 0, 0);

            // Colliding with curveRail that is not rotated
            if ((Mathf.Round(collision.transform.parent.rotation.eulerAngles.z) % 360) == 0) {
                
                // Train travelling from right to left
                if (trainRotation >= 0 && trainRotation < 45 || trainRotation > 270 && trainRotation <= 360) {
                    rotationDirection = Quaternion.Euler(0, 0, Mathf.Round(collision.transform.rotation.eulerAngles.z));
                }
                
                // Train travelling from top to bottom
                if (trainRotation > 45 && trainRotation < 180) {
                    rotationDirection = Quaternion.Euler(0, 0, (Mathf.Round(collision.transform.rotation.eulerAngles.z) - 180));
                }

                // Move train to position of collider (to stop it from leaving the tracks)
                transform.position = new Vector3 (collision.transform.position.x, collision.transform.position.y, 0);
            }

            // Colliding with curveRail that is rotated 90°
            if ((Mathf.Round(collision.transform.parent.rotation.eulerAngles.z) % 360) == 90) {
                rotationDirection = Quaternion.Euler(0, 0, Mathf.Round(collision.transform.rotation.eulerAngles.z));

                // Train travelling from left to right
                if (trainRotation >= 180 && trainRotation <= 270) {
                    rotationDirection = Quaternion.Euler(0, 0, (Mathf.Round(collision.transform.rotation.eulerAngles.z - 180)));
                }

                // Train travelling from top to bottom
                if (trainRotation > 0 && trainRotation < 180) {
                    rotationDirection = Quaternion.Euler(0, 0, (Mathf.Round(collision.transform.rotation.eulerAngles.z)));
                }

                // Move train to position of collider (to stop it from leaving the tracks)
                transform.position = new Vector3 (collision.transform.position.x, collision.transform.position.y, 0);
            }

            // Colliding with curveRail that is rotated 180°
            if ((Mathf.Round(collision.transform.parent.rotation.eulerAngles.z) % 360) == 180) {
                rotationDirection = Quaternion.Euler(0, 0, Mathf.Round(collision.transform.rotation.eulerAngles.z));

                // Train travelling from bottom to top
                if (trainRotation >= 225 && trainRotation <= 360) {
                    rotationDirection = Quaternion.Euler(0, 0, (Mathf.Round(collision.transform.rotation.eulerAngles.z - 180)));
                }
                
                // Train travelling from left to right
                if (trainRotation >= 90 && trainRotation < 225) {
                    rotationDirection = Quaternion.Euler(0, 0, (Mathf.Round(collision.transform.rotation.eulerAngles.z)));
                }

                // Move train to position of collider (to stop it from leaving the tracks)
                transform.position = new Vector3 (collision.transform.position.x, collision.transform.position.y, 0);
            }

            // Colliding with curveRail that is rotated 270°
            if ((Mathf.Round(collision.transform.parent.rotation.eulerAngles.z) % 360) == 270) {

                // Train travelling from right to left
                if (trainRotation >= 0 && trainRotation <= 90 || trainRotation >= 270 && trainRotation <= 360) {
                    rotationDirection = Quaternion.Euler(0, 0, (Mathf.Round(collision.transform.rotation.eulerAngles.z - 180)));
                }

                // Train travelling from bottom to top
                if (trainRotation >= 180 && trainRotation <= 360) {
                    rotationDirection = Quaternion.Euler(0, 0, (Mathf.Round(collision.transform.rotation.eulerAngles.z)));
                }
                
                // Move train to position of collider (to stop it from leaving the tracks)
                transform.position = new Vector3 (collision.transform.position.x, collision.transform.position.y, 0);
            }
            
            transform.rotation = rotationDirection;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionCount--;
    }
}
