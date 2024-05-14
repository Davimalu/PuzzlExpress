using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTexts : MonoBehaviour
{
    [SerializeField]
    [TextArea]
    private List<string> _tutorialTextLines;
    private int _lineIndex;
    
    private Level1Tutorial tutorialScript;
    public GameObject train;
    
    private TMP_Text _text;
    private CanvasGroup _group;
    private bool _started = false;
    // Start is called before the first frame update
    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _group = GetComponent<CanvasGroup>();
        tutorialScript = GetComponent<Level1Tutorial>();
        //_group.alpha = 0;
    }


    private void OnValidate()
    {
        if (_tutorialTextLines.Count > 0) {
            if (_text == null) {
                _text = GetComponent<TMP_Text>();
            }
            _text.SetText(_tutorialTextLines[0]);
            _lineIndex++;
        }
    }


    private void OnMouseDown()
    {
        if (_started == false) {
            Debug.Log("Tutorial aktiviert.");
            //_lineIndex = 0;
            _text.SetText(_tutorialTextLines[_lineIndex++]);
            _group.alpha = 1;
            _started = true;
            Debug.Log("Tutorial Zeile - " + _lineIndex);
        } else if (_lineIndex < _tutorialTextLines.Count - 1) {
            _text.SetText(_tutorialTextLines[_lineIndex++]);
            Debug.Log("Tutorial Zeile - " + _lineIndex);
        } else if (_lineIndex == _tutorialTextLines.Count - 1) {
            _text.SetText(_tutorialTextLines[_lineIndex++]);
            Debug.Log("Tutorial Zeile - " + _lineIndex);
            Debug.Log("Tutorial ist zu Ende.");
            tutorialScript.enabled = true;
            train.GetComponent<BoxCollider2D>().enabled = true;
            //gameObject.AddComponent<ShopItem>();
            //_group.alpha = 0;
        }
    }
}
