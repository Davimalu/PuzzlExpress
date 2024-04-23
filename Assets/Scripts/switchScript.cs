using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchScript : MonoBehaviour
{
    public bool switched = false;
    public SpriteRenderer spriteRenderer;
    public Sprite pos1;
    public Sprite pos2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (switched == true) {
            spriteRenderer.sprite = pos2;
        } else {
            spriteRenderer.sprite = pos1;
        }
    }

    private void OnMouseDown()
    {
        switched = !switched;
    }
}
