using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class TrainScript : MonoBehaviour
{
    private Rigidbody2D train_RigidBody;
    public bool isDriving;
    private int collisionCount = 0;
    private float speed = 5f;
    private bool isInStation = false;

    private switchScript switchScript;

    public Sprite[] skins;

    public AudioSource trainHorn;
    public AudioSource drivingSound;
    public AudioSource starCollect;
    public AudioSource winSound;
    public AudioSource crashSound;
    public UIScript UIScript;
    public GameObject gameOverBg;

    // Start is called before the first frame update
    void Start()
    {
        UIScript = GameObject.Find("Canvas").GetComponent<UIScript>();

        // Disable Vsync and limit frames to 60 FPS
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        switch (PlayerPrefs.GetInt("trainSpeed"))
        {
            case 0:
                speed = 5f;
                break;
            case 1:
                speed = 6.25f;
                break;
        }

        // Get RigidBody Component
        train_RigidBody = GetComponent<Rigidbody2D>();

        Debug.Log(PlayerPrefs.GetInt("skin"));
        GetComponent<SpriteRenderer>().sprite = skins[PlayerPrefs.GetInt("skin")];

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
        else
        {
            drivingSound.Stop();
        }
    }

    private void OnMouseDown()
    {
        if (UIScript.gameIsPaused == false)
        {
            isDriving = true;

            trainHorn.Play();
            drivingSound.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // See https://discussions.unity.com/t/why-does-transform-rotate-behave-so-strange/120303
        double trainRotation = Mathf.Round(transform.rotation.eulerAngles.z) % 360;
        double colliderRotation = Mathf.Round(collision.transform.rotation.eulerAngles.z) % 360;

        collisionCount++;

        // Collision with star
        if (collision.gameObject.tag.Equals("star") == true)
        {
            starCollect.Play();

            int starId = Convert.ToInt32(collision.gameObject.name);
            int currLevel = GameObject.Find("LevelManager").GetComponent<LevelScript>().currLevel;
            string collectedIds = PlayerPrefs.GetString("Level" + currLevel, "");
            if (collectedIds.Length > 0)
                collectedIds += ",";
            collectedIds += starId;
            PlayerPrefs.SetString("Level" + currLevel, collectedIds);
            Destroy(collision.gameObject);
            PlayerPrefs.SetInt("stars", PlayerPrefs.GetInt("stars") + 1);
        }

        // Collision with trainStation - Win Game
        if (collision.gameObject.tag.Equals("trainStation") == true)
        {
            winSound.Play();

            UIScript.WonPanel.SetActive(true);
            isInStation = true;
        }

        if (collision.gameObject.tag.Equals("stationEnd") == true)
        {
            if (!isInStation)
            {
                gameOver();
            }
            else
            {
                won();
            }

            isDriving = false;
        }

        // Collision with straight rail
        if (collision.gameObject.tag.Equals("straightRail") == true)
        {
            // If the rotation of the rail is too different from the rotation of the train -> Stop the train
            if (checkStopStraightRail(trainRotation, colliderRotation))
            {
                isDriving = false;
                gameOver();
            }
        }

        // Collision with curve rail
        if (collision.gameObject.tag.Equals("curveRail") == true)
        {
            // If the rotation of the curve rail is too different than the rotation of the train -> Stop the train 
            if (checkStopCurveRail(trainRotation, colliderRotation))
            {
                isDriving = false;
                gameOver();
            }
        }

        // Collision with switch
        if (collision.gameObject.tag.Equals("switchRail") == true)
        {
            switchScript = collision.GetComponent<switchScript>();

            // Switch in straight position
            if (switchScript.switched == false)
            {
                if (checkStopStraightRail(trainRotation, colliderRotation))
                {
                    isDriving = false;
                    gameOver();
                }
            }
            else
            {
                // Switch in curved position
                if (checkStopCurveRail(trainRotation, colliderRotation))
                {
                    isDriving = false;
                    gameOver();
                }
            }
        }

        // Collision with bufferStop
        if (collision.gameObject.tag.Equals("bufferStop") == true)
        {
            isDriving = false;
            gameOver();
        }

        // Collision with blockedRail
        if (collision.gameObject.tag.Equals("blockedRail") == true)
        {
            isDriving = false;
            gameOver();
        }

        // Collision with direction changer of curveRail
        /* Note: The child of Train (Center Collider) and Curve Rail (Direction Changer) are both on a different layer (curveCollider)
           This ensures that only the collider in the middle of the train (CenterCollider) will collide with the direction changers */
        if (collision.gameObject.tag.Equals("directionChanger") == true)
        {
            // Move train to position of collider (to stop it from leaving the tracks)
            transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, 0);

            Quaternion rotationDirection = getRotationAlongCurve(trainRotation, collision);
            transform.rotation = rotationDirection;
        }

        // Collision with direction changer of switchRail
        /* Note: The child of Train (Center Collider) and Switch Rail (Direction Changer) are both on a different layer (curveCollider)
           This ensures that only the collider in the middle of the train (CenterCollider) will collide with the direction changers */
        if (collision.gameObject.tag.Equals("switchDirectionChanger") == true)
        {
            switchScript = collision.transform.parent.gameObject.GetComponent<switchScript>();

            if (switchScript.switched == true)
            {
                // Move train to position of collider (to stop it from leaving the tracks)
                transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, 0);

                Quaternion rotationDirection = getRotationAlongCurve(trainRotation, collision);
                transform.rotation = rotationDirection;
            }
        }
    }

    private void gameOver()
    {
        Debug.Log("Game over");

        crashSound.Play();

        if (UIScript.GameOverPanel != null)
        {
            UIScript.GameOverPanel.SetActive(true);
        }
    }

    private void won()
    {
        if (GameObject.Find("LevelManager") == null) return;

        int currLevel = GameObject.Find("LevelManager").GetComponent<LevelScript>().currLevel;
        int unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels");
        Debug.Log(currLevel + " " + unlockedLevels + " " + (currLevel == unlockedLevels));
        if (currLevel == unlockedLevels)
        {
            unlockedLevels++;
            PlayerPrefs.SetInt("UnlockedLevels", unlockedLevels);
            Debug.Log(PlayerPrefs.GetInt("UnnlockedLevels").ToString());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionCount--;

        // The train should only collide with an object once | As soon as the train leaves the object, disable its collider
        collision.enabled = false;

        if (collisionCount == 0)
        {
            gameOver();
        }
    }

    private bool checkStopStraightRail(double trainRotation, double colliderRotation)
    {
        // Train travelling from right to left
        if (trainRotation < 45 || trainRotation > 315)
        {
            if (colliderRotation != 0 && colliderRotation != 180)
            {
                Debug.Log("Stop A");
                return true;
            }
        }

        // Train travelling from left to right
        if (trainRotation > 135 && trainRotation < 225)
        {
            if (colliderRotation != 0 && colliderRotation != 180)
            {
                Debug.Log("Stop B");
                return true;
            }
        }

        // Train travelling from top to bottom
        if (trainRotation > 45 && trainRotation < 135)
        {
            if (colliderRotation != 90 && colliderRotation != 270)
            {
                Debug.Log("Stop C");
                return true;
            }
        }

        // Train travelling from bottom to top
        if (trainRotation > 225 && trainRotation < 315)
        {
            if (colliderRotation != 90 && colliderRotation != 270)
            {
                Debug.Log("Stop D");
                return true;
            }
        }

        return false;
    }

    private bool checkStopCurveRail(double trainRotation, double colliderRotation)
    {
        // Train travelling from right to left
        if (trainRotation < 45 || trainRotation > 315)
        {
            if (colliderRotation != 0 && colliderRotation != 270)
            {
                Debug.Log("Stop E");
                return true;
            }
        }

        // Train travelling from left to right
        if (trainRotation > 135 && trainRotation < 225)
        {
            if (colliderRotation != 90 && colliderRotation != 180)
            {
                Debug.Log("Stop F");
                return true;
            }
        }

        // Train travelling from top to bottom
        if (trainRotation > 45 && trainRotation < 135)
        {
            if (colliderRotation != 0 && colliderRotation != 90)
            {
                Debug.Log("Stop G");
                return true;
            }
        }

        // Train travelling from bottom to top
        if (trainRotation > 225 && trainRotation < 315)
        {
            if (colliderRotation != 180 && colliderRotation != 270)
            {
                Debug.Log("Stop H");
                return true;
            }
        }

        return false;
    }

    private Quaternion getRotationAlongCurve(double trainRotation, Collider2D collision)
    {
        // Colliding with curveRail that is not rotated
        if ((Mathf.Round(collision.transform.parent.rotation.eulerAngles.z) % 360) == 0)
        {

            // Train travelling from right to left
            if (trainRotation >= 0 && trainRotation < 45 || trainRotation > 270 && trainRotation <= 360)
            {
                return Quaternion.Euler(0, 0, Mathf.Round(collision.transform.rotation.eulerAngles.z));
            }

            // Train travelling from top to bottom
            if (trainRotation > 45 && trainRotation < 180)
            {
                return Quaternion.Euler(0, 0, (Mathf.Round(collision.transform.rotation.eulerAngles.z) - 180));
            }
        }

        // Colliding with curveRail that is rotated 90°
        if ((Mathf.Round(collision.transform.parent.rotation.eulerAngles.z) % 360) == 90)
        {

            // Train travelling from left to right
            if (trainRotation >= 180 && trainRotation <= 270)
            {
                return Quaternion.Euler(0, 0, (Mathf.Round(collision.transform.rotation.eulerAngles.z - 180)));
            }

            // Train travelling from top to bottom
            if (trainRotation > 0 && trainRotation < 180)
            {
                return Quaternion.Euler(0, 0, (Mathf.Round(collision.transform.rotation.eulerAngles.z)));
            }
        }

        // Colliding with curveRail that is rotated 180°
        if ((Mathf.Round(collision.transform.parent.rotation.eulerAngles.z) % 360) == 180)
        {

            // Train travelling from bottom to top
            if (trainRotation >= 225 && trainRotation <= 360)
            {
                return Quaternion.Euler(0, 0, (Mathf.Round(collision.transform.rotation.eulerAngles.z - 180)));
            }

            // Train travelling from left to right
            if (trainRotation >= 90 && trainRotation < 225)
            {
                return Quaternion.Euler(0, 0, (Mathf.Round(collision.transform.rotation.eulerAngles.z)));
            }
        }

        // Colliding with curveRail that is rotated 270°
        if ((Mathf.Round(collision.transform.parent.rotation.eulerAngles.z) % 360) == 270)
        {

            // Train travelling from right to left
            if (trainRotation < 90 || trainRotation > 315)
            {
                return Quaternion.Euler(0, 0, (Mathf.Round(collision.transform.rotation.eulerAngles.z - 180)));
            }

            // Train travelling from bottom to top
            if (trainRotation > 180 && trainRotation < 315)
            {
                return Quaternion.Euler(0, 0, (Mathf.Round(collision.transform.rotation.eulerAngles.z)));
            }
        }

        return Quaternion.Euler(0, 0, 0);
    }
}

