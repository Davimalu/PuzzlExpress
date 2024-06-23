using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialCreater : MonoBehaviour
{
    [SerializeField]
    [TextArea]
    private List<string> _tutorialTextLines; // Creates a list, used to add texts
    private int lineIndex = 0; // Used to show which text line we currently are on
    private GameObject train;
    private GameObject trainStation;
    private GameObject backgroundDarkener;
    private GameObject continueText;
    public List<GameObject> _arrows; // Creates a list, used to add arrows
    public List<GameObject> _highlightObjects; // Creates a list, used to add highlighted objects
    public GameObject rail; // The chosen rail
    public int rotateRailTo; // The z value the rail has to be rotated to in order to advance in the tutorial
    private TMP_Text _text; // In order to use/configure the Text Mash Pro and display the texts in the list
    private Coroutine typingCoroutine; // Displays the texts
    private bool isShortTutorial = false; // Determines how the tutorial works, true if there is nothing to show in the tutorial and false if a new rail is getting described
    private bool isTutorialStillRunning = true; 

    
    // Start is called before the first frame update
    private void Start()
    {
        train = GameObject.Find("Train");
        trainStation = GameObject.Find("TrainStation");
        backgroundDarkener = GameObject.Find("BackgroundDarkener");
        continueText = GameObject.Find("ContinueTextAdjuster");
        _text = GetComponent<TMP_Text>();
        typingCoroutine = StartCoroutine (TextTypingEffect()); // Shows the First Text with an Typewriter effect

        // Checks if there is only one text, meaning that its a short tutorial
        if (_tutorialTextLines.Count == 1) {
            isShortTutorial = true;
        } 
        // Else, its a long tutorial
        else {
            lineIndex++;
            Debug.Log("Tutorial started");
            Debug.Log("Tutorial Line - " + lineIndex);
        }
    }

    private void Update()
    {
        // If tutorial is finished or its a short tutorial
        if (isTutorialStillRunning == false || isShortTutorial == true) {
            return;
        }

        // If there is no rail assigned and the Rail StraightRailNew exists (Only the case if the blocked rail got cleared)
        if (rail == null && GameObject.Find("StraightRailNew") != null) {
            StopCoroutine(typingCoroutine); // Stops the Typing/Text Coroutine
            typingCoroutine = StartCoroutine (TextTypingEffect()); // Shows the next Text with an Typewriter effect
            rail = GameObject.Find("StraightRailNew");
            rail.GetComponent<SpriteRenderer>().sortingOrder = 1; // Increase the Sorting layer, in order to highlight it in the tutorial
        }

        // Checks if the rail has been rotated correctly and the tutorial is still running
        if (IsRailRotatedCorrectly() && isTutorialStillRunning == true) {
            _text.SetText(_tutorialTextLines[lineIndex++]); // Sets text to the next one
            Debug.Log("Tutorial Line - " + lineIndex);
            Debug.Log("Tutorial finished.");
            this.GetComponent<BoxCollider2D>().enabled = false; // Disables the text boxes collider, since the last text has been reached and it would otherwise interfere with the gameplay
            train.GetComponent<BoxCollider2D>().enabled = true; // Enables the trains Collider, to make it clickable
            train.transform.Find("CenterCollider").GetComponent<BoxCollider2D>().enabled = true; // Enables the trains Central Collider, in order to make the train function correctly

            // Goes through all higlighted
            foreach (GameObject obj in _highlightObjects) {
                obj.GetComponent<SpriteRenderer>().sortingOrder = 0; // Sets the highlighted objects layer to 0, in order to remove the highlighting effect
            }

            rail.GetComponent<SpriteRenderer>().sortingOrder = 0; // Sets the rails layer to 0, in order to remove the highligting effect
            train.GetComponent<SpriteRenderer>().sortingOrder = 0; // Sets the trains layer to 0, in order to remove the highligting effect
            trainStation.GetComponent<SpriteRenderer>().sortingOrder = 1; // Sets the train stations layer to 1, in order to hide the train when it drives into the train station

            // Goes though all arrows
            foreach (GameObject arrow in _arrows) {
                arrow.SetActive(false); // Disables the arrow
            }

            continueText.SetActive(false); // Disables the small "click to continue text" label, since the last text has been reached
            backgroundDarkener.SetActive(false); // Disables the Background darkener, since tutorial is over and the player can now interact with the objects
            isTutorialStillRunning = false; // Set it to false, since tutorial is over
        }
    }

    // Stops the tutorial text from advancing after clicking the pause button
    private bool toggleTutorial()
    {
        if (GameObject.Find("PauseMenu") != null) {
            return true;
        }
        else {
            return false;
        }
    }

    // If the mouse button is clicked
    private void OnMouseDown()
    {
        // If the tutorial is over, its a short tutorial or pause has been clicked
        if (isTutorialStillRunning == false || isShortTutorial == true || toggleTutorial() == true) {
            return; // Return, since the other parts arent needed
        }

        // If the Current text isnt the last
        if (lineIndex < _tutorialTextLines.Count - 1) {
            StopCoroutine(typingCoroutine); // Stops the Typing/Text Coroutine
            typingCoroutine = StartCoroutine (TextTypingEffect()); // Show the next text
            lineIndex++;
            Debug.Log("Tutorial Line - " + lineIndex);
        } 
        // Else if the current text is the last text
        else if (lineIndex == _tutorialTextLines.Count - 1) {
            // Go through all arrows
            foreach (GameObject arrow in _arrows) {
                arrow.SetActive(false); // Disable arrow
            }
            // Go through all highlighted objects
            foreach (GameObject obj in _highlightObjects) {
                obj.GetComponent<SpriteRenderer>().sortingOrder = 0; // Set layer to 0, in order to remove the highlighting
            }
            isTutorialStillRunning = false;
            StopCoroutine(typingCoroutine); // Stop the last text, if its still getting typed out
            typingCoroutine = StartCoroutine (TextTypingEffect()); // Type the last text
            lineIndex++;
            Debug.Log("Tutorial Line - " + lineIndex);
            Debug.Log("Tutorial finished.");
            this.GetComponent<BoxCollider2D>().enabled = false; // Disable the tutorials collider
            train.GetComponent<BoxCollider2D>().enabled = true; // Enable the trains collider
            train.transform.Find("CenterCollider").GetComponent<BoxCollider2D>().enabled = true; // Enable the CenterColliders collider
            train.GetComponent<SpriteRenderer>().sortingOrder = 0; // Set trains layer to 0, in order to hide the train behind the train station
            trainStation.GetComponent<SpriteRenderer>().sortingOrder = 1; // Set train stations layer to 1, in order to hide the train behind it
            continueText.SetActive(false); // Disable the small continue text label, since the last text has been reached
            backgroundDarkener.SetActive(false); // Disable the background darkener, since tutorial is finished
            return;
        }

        switch (lineIndex) {
            case 2: {
                if (_highlightObjects.Count > 0) {
                    // Go through all highlighted Objects
                    foreach (GameObject obj in _highlightObjects) {
                        obj.GetComponent<SpriteRenderer>().sortingOrder = 1; // Set layer to 1, in order to highlight the object
                    }
                    StartCoroutine (ShowArrows()); // Start showing the arrows
                } else {
                    rail.GetComponent<SpriteRenderer>().sortingOrder = 1; // Set trains layer to 1, in order to highlight it
                }
                break;
            }
            case 3: {
                // if rail is null, meaning no rail has been chosen
                if (rail != null) {
                    StartCoroutine (ShowArrows()); // Show arrows
                    this.GetComponent<BoxCollider2D>().enabled = false; // Disable the tutorials collider
                    rail.GetComponent<BoxCollider2D>().enabled = true; // Enable the rails collider, in order to make it clickable
                }
                break;
            }
        }
    }

    // Checks if trail has been rotated corrently and returns true or false
    private bool IsRailRotatedCorrectly() {
        // If the text hasnt reached the last two texts or no rail has been selected/rail is null
        if (lineIndex <= _tutorialTextLines.Count - 2 || rail == null) {
            return false;
        }

        // If a straight rail has been chosen
        if (rail.name.Contains("StraightRail")) {
            // If the rail has the correct Z value/its rotated correctly
            if (rail.transform.rotation.eulerAngles.z == rotateRailTo) {
                rail.GetComponent<StraightRailScript>().isRotateable = false; // Disable the rotation functuionality of the rail
                return true;
            }
        } else if (rail.name.Contains("CurveRail")) {
            // If the rail has the correct Z value/its rotated correctly
            if (rail.transform.rotation.eulerAngles.z == rotateRailTo) {
                rail.GetComponent<CurvedRailScript>().isRotateable = false; // Disable the rotation functuionality of the rail
                return true;
            }
        } else if (rail.name.Contains("Switch")) {
            // If the sprite has the correct name/is rotated correctly
            switch (rail.GetComponent<SpriteRenderer>().sprite.name) {
                case "weichePos1": return false;
                case "weichePos2": rail.GetComponent<switchScript>().isRotateable = false; // Disable the rotation functuionality of the rail
                    return true;
            }
        } 

        return false;
    }

    // Enables the arrows
    IEnumerator ShowArrows()
    {
        yield return new WaitForSeconds(1.4f); // Wait for 1.4sec
        // Go throgh all arrows
        foreach (GameObject arrow in _arrows) {
            // If the text has been skipped and therefore reached the next text
            if(lineIndex >= _tutorialTextLines.Count) {
                break; // Since next text has been reached and the arrows are no longer needed
            }
            arrow.SetActive(true); // Enable arrow
            yield return new WaitForSeconds(0.7f); // Wait for 0.7sec
        }
    }

    // Shows the text using a Typewriter effect
    IEnumerator TextTypingEffect()
    {
        string text = "";
        // Go through all characters of the text
        foreach (char c in _tutorialTextLines[lineIndex]) {
            text += c; // Add character to visible text
            _text.SetText(text); // Set updated value as text
            yield return new WaitForSeconds(0.01f); // Wait for 0.01sec before showing the next letter
        }
    }
}
