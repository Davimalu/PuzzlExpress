using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialLevel2 : MonoBehaviour
{
    [SerializeField]
    [TextArea]
    private List<string> _tutorialTextLines;
    private int _lineIndex;
    
    public GameObject train;
    public GameObject trainStation;
    public GameObject backgroundDarkener;
    public GameObject continueText;
    public List<GameObject> _arrows;
    public List<GameObject> rails;
    
    private TMP_Text _text;
    private bool isTutorialStillRunning = true;
    private CanvasGroup _group;
    
    // Start is called before the first frame update
    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _group = GetComponent<CanvasGroup>();
        Debug.Log("Tutorial started");
        Debug.Log("Tutorial Line - 1");
        //_group.alpha = 0;
        if (_tutorialTextLines.Count > 0) {
            if (_text == null) {
                _text = GetComponent<TMP_Text>();
            }
            StartCoroutine (TextTypingEffect());
            //_text.SetText(_tutorialTextLines[0]);
            _lineIndex++;
        }
    }

    private void Update()
    {
        if (rails[0].transform.rotation.eulerAngles.z == 180 && isTutorialStillRunning == true) {
            //_text.SetText(_tutorialTextLines[_lineIndex++]);
            StartCoroutine (TextTypingEffect());
            _lineIndex++;
            Debug.Log("Tutorial Line - " + _lineIndex);
            Debug.Log("Tutorial finished.");
            this.GetComponent<BoxCollider2D>().enabled = false;
            train.GetComponent<BoxCollider2D>().enabled = true;
            rails[0].GetComponent<StraightRailScript>().enabled = false;
            rails[0].GetComponent<SpriteRenderer>().sortingOrder = 0;
            trainStation.GetComponent<SpriteRenderer>().sortingOrder = 1;
            _arrows[0].SetActive(false);
            continueText.SetActive(false);
            backgroundDarkener.SetActive(false);
            isTutorialStillRunning = false;
            return;
        }
    }

    IEnumerator ShowArrows()
    {
        yield return new WaitForSeconds(2f);
        _arrows[0].SetActive(true);
    }

    IEnumerator TextTypingEffect()
    {
        string text = "";
        foreach (char c in _tutorialTextLines[_lineIndex]) {
            text += c;
            _text.SetText(text);
            yield return new WaitForSeconds(0.01f);
        }
    }

    /*private void OnValidate()
    {
        if (_tutorialTextLines.Count > 0) {
            if (_text == null) {
                _text = GetComponent<TMP_Text>();
            }
            _text.SetText(_tutorialTextLines[0]);
            _lineIndex++;
        }
    }*/


    private void OnMouseDown()
    {
        if (_lineIndex < _tutorialTextLines.Count - 1) {
            //_text.SetText(_tutorialTextLines[_lineIndex++]);
            StartCoroutine (TextTypingEffect());
            _lineIndex++;
            Debug.Log("Tutorial Line - " + _lineIndex);
            switch (_lineIndex) {
                case 2: {
                    StartCoroutine (ShowArrows());
                    break;
                }
                case 3: {
                    rails[0].GetComponent<BoxCollider2D>().enabled = true;
                    this.GetComponent<BoxCollider2D>().enabled = false;
                    rails[0].GetComponent<SpriteRenderer>().sortingOrder = 1;
                    break;
                }
            }
        } 
    }
}

