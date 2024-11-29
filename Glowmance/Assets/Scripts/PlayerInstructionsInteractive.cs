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
            StopAllCoroutines();
            _textComponent.text = _lines[_index];
        }

        if (_textComponent.text == _lines[0] && (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)))
        {
            NextLine();
        }

        if (_textComponent.text == _lines[1] && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)))
        {
            NextLine();
        }

        if (_textComponent.text == _lines[2] && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)))
        {
            NextLine();
        }

        if (_textComponent.text == _lines[3] && Input.GetKeyDown(KeyCode.F))
        {
            NextLine();
        }
    }

    public void StartInstructions()
    {
        Debug.Log("Instructions started");
        _index = 0;
        _dialogueRunning = true;
        StartCoroutine(TypeLine());
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

// Press the right arrow key or 'd' key to move Lumina right
// Press the left arrow key or 'a' key to move Lumina left
// Press the up arrow key or 'w' key to make Lumina jump
// Press the 'f' key to toggle Lumina's tail glow light on and off