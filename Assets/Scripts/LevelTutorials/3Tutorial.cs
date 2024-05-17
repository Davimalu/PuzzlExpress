using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialLevel3 : MonoBehaviour
{
    [SerializeField]
    [TextArea]
    private List<string> _tutorialTextLines;
    private int _lineIndex;

    private TMP_Text _text;
    private CanvasGroup _group;
    
    // Start is called before the first frame update
    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _group = GetComponent<CanvasGroup>();
        //_group.alpha = 0;
        StartCoroutine (TextTypingEffect());
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

    private void Update()
    {
       
    }

    /*IEnumerator ShowArrows()
    {
        yield return new WaitForSeconds(0.6f);
        _arrows[0].SetActive(true);
    }*/

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


    /*private void OnMouseDown()
    {
        if (_lineIndex < _tutorialTextLines.Count - 1) {
            _text.SetText(_tutorialTextLines[_lineIndex++]);
            Debug.Log("Tutorial Line - " + _lineIndex);
        } 
    }*/
}