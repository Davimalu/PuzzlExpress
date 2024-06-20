using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartTutorial : MonoBehaviour
{
    public float timeToWait = 2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (TriggerTutorial()); // Starts displaying the tutorial
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Triggers the tutorial
    IEnumerator TriggerTutorial()
    {
        yield return new WaitForSeconds(timeToWait); // Wait for 4.5sec
        // Go through all children
        foreach (Transform child in transform)
        {
            // If the childs name doesnt contain Arrow
            if (!child.name.Contains("Arrow")) {
                // If the childs name is teacher or SpeechBox
                if (child.name == "teacher" || child.name == "SpeechBox") {
                    yield return new WaitForSeconds(0.5f); // Wait for 0.5sec
                }
                child.gameObject.SetActive(true); // Activate the child
                yield return StartCoroutine(FadeInImage(child.gameObject, 0.5f)); // Fade in the child
            }
        }
    }

    // Fades in images
    public static IEnumerator FadeInImage(GameObject gameObject, float duration)
    {
        Image image = gameObject.GetComponent<Image>(); // Get the GameObjects image component
        float elapsedTime = 0f;
        Color initialColor = image.color; // Create a variable with the values of iamge.color
        initialColor.a = 0f; // Set the alpha to 0
        image.color = initialColor; // Insert the new variables values, in order to make the images alpha 0

        // While the elapsedTime is lower than the duration
        while (elapsedTime < duration) {
            float alpha = Mathf.Clamp01(elapsedTime / duration); // If the result is less than 0, returns 0 and if its more than 1, returns 1
            // If the images name contains BackgroundDarkener and its alpha is more than 79%
            if (image.name.Contains("BackgroundDarkener") && alpha > 0.79) {
                break;
            }
            image.color = new Color(initialColor.r, initialColor.g, initialColor.b, alpha); // RGB values stay the same, only alpha is getting updated
            elapsedTime += Time.deltaTime; // Increases elapsedTime by the amount of time that has passed since the last frame
            yield return null; // Pauses the Coroutine until the next frame
        }
    }
}