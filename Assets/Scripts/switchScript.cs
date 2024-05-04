using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchScript : MonoBehaviour
{
    public bool switched = false;
    public SpriteRenderer spriteRenderer;
    public Sprite pos1;
    public Sprite pos2;
    private TrainScript trainScript;

    // Start is called before the first frame update
    void Start()
    {
        trainScript = GameObject.FindGameObjectWithTag("train").GetComponent<TrainScript>();
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
        // Switching only possible if the train is not driving
        if (trainScript.isDriving == false)
        {
            switched = !switched;
        }
    }
}
