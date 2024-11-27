using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class RespawnMessage : MonoBehaviour
{
    Image _respawnBg;
    [SerializeField] TextMeshProUGUI _textComponent;
    public bool _dialogueRunning;
    public GameObject _lumina;

    void Awake()
    {
        _textComponent.text = "Oh, no! Lumina has fallen into darkness - she will respawn at her closet checkpoint.";
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _respawnBg = gameObject.GetComponent<Image>();
        gameObject.SetActive(false);
        _lumina = GameObject.FindGameObjectWithTag("Player");

    }

    public void runRespawnMessage(int deathType)
    {
        _dialogueRunning = true;
        if (deathType == 1)
        {
            _textComponent.text = "Oh no! The spider has eaten Lumina! She will respawn at her closest checkpoint.";
        }

        // Show respawn message box
        gameObject.SetActive(true);
        _respawnBg.GetComponent<Image>().color = new Color(_respawnBg.GetComponent<Image>().color.r, _respawnBg.GetComponent<Image>().color.g, _respawnBg.GetComponent<Image>().color.b, 255);

        StartCoroutine(RespawnWait());
    }

    IEnumerator RespawnWait()
    {
        yield return new WaitForSeconds(4);
        gameObject.SetActive(false);
        _dialogueRunning = false;
    }
}
