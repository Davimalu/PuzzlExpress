using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialCreater : MonoBehaviour
{
    [SerializeField]
    [TextArea]
    private List<string> _tutorialTextLines;
    private int lineIndex = 0;
    
    public GameObject train;
    public GameObject trainStation;
    public GameObject backgroundDarkener;
    public GameObject continueText;
    public List<GameObject> _arrows;
    public List<GameObject> _highlightObjects;
    public GameObject rail;
    public int rotateRailTo;
    
    private TMP_Text _text;
    private bool isShortTutorial = false;
    private bool isTutorialStillRunning = true;
    private Coroutine typingCoroutine;
    
    // Start is called before the first frame update
    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        typingCoroutine = StartCoroutine (TextTypingEffect());

        if (_tutorialTextLines.Count == 1) {
            isShortTutorial = true;
        } else {
            lineIndex++;
            Debug.Log("Tutorial started");
            Debug.Log("Tutorial Line - " + lineIndex);
            //train.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void Update()
    {
        if (isTutorialStillRunning == false || isShortTutorial == true) {
            return;
        }

        if (rail == null && GameObject.Find("StraightRailNew") != null) {
            StopCoroutine(typingCoroutine);
            typingCoroutine = StartCoroutine (TextTypingEffect());
            //lineIndex++; 
            rail = GameObject.Find("StraightRailNew");
            rail.GetComponent<SpriteRenderer>().sortingOrder = 1; 
        }

        if (IsRailRotatedCorrectly() && isTutorialStillRunning == true) {
            _text.SetText(_tutorialTextLines[lineIndex++]);
            Debug.Log("Tutorial Line - " + lineIndex);
            Debug.Log("Tutorial finished.");
            this.GetComponent<BoxCollider2D>().enabled = false;
            train.GetComponent<BoxCollider2D>().enabled = true;
            train.transform.Find("CenterCollider").GetComponent<BoxCollider2D>().enabled = true;

            foreach (GameObject obj in _highlightObjects) {
                obj.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }

            rail.GetComponent<SpriteRenderer>().sortingOrder = 0;
            train.GetComponent<SpriteRenderer>().sortingOrder = 0;
            trainStation.GetComponent<SpriteRenderer>().sortingOrder = 1;

            foreach (GameObject arrow in _arrows) {
                arrow.SetActive(false);
            }

            continueText.SetActive(false);
            backgroundDarkener.SetActive(false);
            isTutorialStillRunning = false;
        }
    }

    private void OnMouseDown()
    {
        if (isTutorialStillRunning == false || isShortTutorial == true) {
            return;
        }

        if (lineIndex < _tutorialTextLines.Count - 1) {
            StopCoroutine(typingCoroutine);
            typingCoroutine = StartCoroutine (TextTypingEffect());
            lineIndex++;
            Debug.Log("Tutorial Line - " + lineIndex);
        } else if (lineIndex == _tutorialTextLines.Count - 1) {
            foreach (GameObject arrow in _arrows) {
                arrow.SetActive(false);
            }
            foreach (GameObject obj in _highlightObjects) {
                obj.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            isTutorialStillRunning = false;
            StopCoroutine(typingCoroutine);
            typingCoroutine = StartCoroutine (TextTypingEffect());
            lineIndex++;
            Debug.Log("Tutorial Line - " + lineIndex);
            Debug.Log("Tutorial finished.");
            this.GetComponent<BoxCollider2D>().enabled = false;
            train.GetComponent<BoxCollider2D>().enabled = true;
            train.transform.Find("CenterCollider").GetComponent<BoxCollider2D>().enabled = true;
            train.GetComponent<SpriteRenderer>().sortingOrder = 0;
            trainStation.GetComponent<SpriteRenderer>().sortingOrder = 1;
            continueText.SetActive(false);
            backgroundDarkener.SetActive(false);
            return;
        }

        switch (lineIndex) {
            case 2: {
                if (_highlightObjects.Count > 0) {
                    foreach (GameObject obj in _highlightObjects) {
                        obj.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    }
                    StartCoroutine (ShowArrows());
                } else {
                    rail.GetComponent<SpriteRenderer>().sortingOrder = 1;
                }
                break;
            }
            case 3: {
                if (rail != null) {
                    StartCoroutine (ShowArrows());
                    this.GetComponent<BoxCollider2D>().enabled = false;
                    rail.GetComponent<BoxCollider2D>().enabled = true;
                }
                break;
            }
        }
    }

    private bool IsRailRotatedCorrectly() {
        if (lineIndex <= _tutorialTextLines.Count - 2 || rail == null) {
            return false;
        }

        if (rail.name.Contains("StraightRail")) {
            if (rail.transform.rotation.eulerAngles.z == rotateRailTo) {
                rail.GetComponent<StraightRailScript>().isRotateable = false;
                return true;
            }
        } else if (rail.name.Contains("CurveRail")) {
            if (rail.transform.rotation.eulerAngles.z == rotateRailTo) {
                rail.GetComponent<CurvedRailScript>().isRotateable = false;
                return true;
            }
        } else if (rail.name.Contains("Switch")) {
            switch (rail.GetComponent<SpriteRenderer>().sprite.name) {
                case "weichePos1": return false;
                case "weichePos2": rail.GetComponent<switchScript>().isRotateable = false;
                    return true;
            }
        } 

        return false;
    }

    IEnumerator ShowArrows()
    {
        yield return new WaitForSeconds(1.4f);
        foreach (GameObject arrow in _arrows) {
            if(lineIndex >= _tutorialTextLines.Count) {
                break;
            }
            //yield return StartCoroutine(StartTutorial.FadeInMesh(arrow, 1f));
            arrow.SetActive(true);
            yield return new WaitForSeconds(0.7f);
        }
    }

    IEnumerator TextTypingEffect()
    {
        string text = "";
        foreach (char c in _tutorialTextLines[lineIndex]) {
            text += c;
            _text.SetText(text);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
