using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockedRailSript : MonoBehaviour
{
    public GameObject obj;
    private TrainScript trainScript;
    private AudioSource chainsaw;
    public AudioClip audioStrip;
    public Animator chainsawAniamator;
    public UIScript UIScript;


    // Start is called before the first frame update
    void Start()
    {
        trainScript = GameObject.FindGameObjectWithTag("train").GetComponent<TrainScript>();
        chainsawAniamator = gameObject.transform.GetChild(1).GetComponent<Animator>();
        UIScript = GameObject.Find("Canvas").GetComponent<UIScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Debug.Log("Klick auf blockierte Schiene");

        // Removing tree only possible if the train is not driving
        if (trainScript.isDriving == false && UIScript.gameIsPaused == false)
        {
            // Play chainsaw animation
            var chainsawObj = gameObject.transform.GetChild(1).gameObject;
            chainsawObj.SetActive(true);

            // Make the child (straightRail) to a top-level object, then delete the blocked Rail
            var child = gameObject.transform.GetChild(0).gameObject;
            child.transform.SetParent(null);

            chainsaw = GetComponent<AudioSource>();
            chainsaw.clip = audioStrip;
            chainsaw.Play();
            StartCoroutine(WaitForSound(audioStrip));
        }
    }

    public IEnumerator WaitForSound(AudioClip Sound)
    {
        yield return new WaitUntil(() => chainsaw.isPlaying == false);
        // or yield return new WaitWhile(() => audiosource.isPlaying == true);
        if (obj != null)
            Destroy(gameObject);
    }
}
