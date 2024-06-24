using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class JunctionRailScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Enables collider after 1 sec
    static IEnumerator EnableColidderAgain(Collider2D collision)
    {
        yield return new WaitForSeconds(0.5f);
        collision.GetComponent<Collider2D>().enabled = true;
    }

    void OnTriggerExit2D()
    {
        // Enables junction rails collider again, since otherwise the train wouldnt be able to drive on it again
        StartCoroutine(EnableColidderAgain(this.GetComponent<Collider2D>()));
    }
}
