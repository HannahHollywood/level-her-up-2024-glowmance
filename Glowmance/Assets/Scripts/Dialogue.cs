using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.InputSystem;

public class Dialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textComponent;
    [SerializeField] string[] _lines;
    [SerializeField] float _textSpeed;
    int _index;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.SetActive(false);
        _textComponent.text = string.Empty;
        // Debug.Log(_textComponent.text);
        // StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
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

    public void StartDialogue()
    {
        _index = 0;
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
            gameObject.SetActive(false);
        }
    }
}

// TEXT: 
// Lumina,

// The light of my life, I glow dimmer each night without you!

// Perched atop our little ledge I wait, hoping that every flicker of my light may guide you back home to safety. 

// Shining just for you,
// Ray



// <b>PRESS ANY KEY</b>