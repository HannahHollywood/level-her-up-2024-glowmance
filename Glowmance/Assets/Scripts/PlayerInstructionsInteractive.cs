using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerInstructionsInteractive : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textComponent;
    [SerializeField] string[] _lines;
    [SerializeField] float _textSpeed;
    int _index;
    public bool _dialogueRunning;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
        _textComponent.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_textComponent.text == _lines[_index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                _textComponent.text = _lines[_index];
            }
        }
    }

    public void StartInstructions()
    {
        _index = 0;
        _dialogueRunning = true;
        StartCoroutine(TypeLine());
        Debug.Log("dialogue started");
    }

    IEnumerator TypeLine()
    {
        foreach (char c in _lines[_index].ToCharArray())
        {
            _textComponent.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    void NextLine()
    {
        if (_index < _lines.Length - 1)
        {
            _index++;
            _textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            _dialogueRunning = false;
            gameObject.SetActive(false);
        }
    }
}


// <b>Controls</b>
// <br>
// <color=#C2CB5C> Left Arrow </color=#C2CB5C>or <color=#C2CB5C>  'a' key </color=#C2CB5C>- Move left
// <br>
// <color=#C2CB5C> Right Arrow </color=#C2CB5C>or <color=#C2CB5C>  'd' key </color=#C2CB5C>- Move right
// <br>
// <color=#C2CB5C> Up Arrow </color=#C2CB5C> or <color=#C2CB5C>  'w' key </color=#C2CB5C> - Jump
// <br>
// <color=#C2CB5C>  'f' key </color=#C2CB5C> - Toggle glow tail light on and off