using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class TutorialLevel1: MonoBehaviour
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
    public GameObject speechBox;
    
    private TMP_Text _text;
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

    IEnumerator ShowArrows()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; _lineIndex != 3 && i < 3; i++) {
            _arrows[i].SetActive(true);
            yield return new WaitForSeconds(0.6f);
        }
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
            //StartCoroutine (TextTypingEffect());
            //_text.SetText(_tutorialTextLines[0]);
            _lineIndex++;
        }
    }*/


    private void OnMouseDown()
    {
        if (_lineIndex < _tutorialTextLines.Count - 1) {
            StartCoroutine (TextTypingEffect());
            _lineIndex++;
            Debug.Log("Tutorial Line - " + _lineIndex);
            switch (_lineIndex) {
                case 2: {
                    train.GetComponent<SpriteRenderer>().sortingOrder = 1;
                    trainStation.GetComponent<SpriteRenderer>().sortingOrder = 2;
                    StartCoroutine (ShowArrows());
                    break;
                }
            }
        } else if (_lineIndex == _tutorialTextLines.Count - 1) {
            //_text.SetText(_tutorialTextLines[_lineIndex++]);
            StartCoroutine (TextTypingEffect());
            _lineIndex++;
            Debug.Log("Tutorial Line - " + _lineIndex);
            Debug.Log("Tutorial finished.");
            this.GetComponent<BoxCollider2D>().enabled = false;
            train.GetComponent<BoxCollider2D>().enabled = true;
            _arrows[0].SetActive(false);
            _arrows[1].SetActive(false);
            _arrows[2].SetActive(false);
            continueText.SetActive(false);
            backgroundDarkener.SetActive(false);
            //gameObject.AddComponent<ShopItem>();
            //_group.alpha = 0;
        }
    }
}

