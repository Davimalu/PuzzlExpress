using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchScript : MonoBehaviour
{
    [SerializeField]
    public bool switched = false;
    public SpriteRenderer spriteRenderer;
    public Sprite pos1;
    public Sprite pos2;
    private TrainScript trainScript;
    public AudioSource clickSound;
    public UIScript UIScript;
    public bool isMirrored = false;
    public bool isRotateable = true;

    // Start is called before the first frame update
    void Start()
    {
        trainScript = GameObject.FindGameObjectWithTag("train").GetComponent<TrainScript>();
        UIScript = GameObject.Find("Canvas").GetComponent<UIScript>();
        if (isMirrored == true) {
            Transform lastChild = transform.GetChild(4);
            lastChild.rotation = Quaternion.Euler(lastChild.rotation.eulerAngles.x, lastChild.rotation.eulerAngles.y, lastChild.rotation.eulerAngles.z - 180);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (switched == true)
        {
            spriteRenderer.sprite = pos2;
        }
        else
        {
            spriteRenderer.sprite = pos1;
        }
    }

    private void OnMouseDown()
    {
        // Switching only possible if the train is not driving and rail is clickable
        if (trainScript.isDriving == false && UIScript.gameIsPaused == false && isRotateable == true)
        {
            switched = !switched;
            clickSound.Play();
        }
    }
}
