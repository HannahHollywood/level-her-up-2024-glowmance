using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject endGame;
    public GameOverScene gameOverScene;
    public GameObject dialogueBox;
    Dialogue _dialogue;
    public GameObject respawnMessage;
    RespawnMessage _respawnMessageScript;
    public GameObject _staticInstructions;
    staticInstructions _staticInstructionsScript;
    public GameObject _instructionsTutorial;
    PlayerInstructionsInteractive _instructionsTutorialScript;
    public bool _pauseMovement;

    void Awake()
    {
        gameOverScene = endGame.GetComponent<GameOverScene>();
        _dialogue = dialogueBox.GetComponent<Dialogue>();
        _respawnMessageScript = respawnMessage.GetComponent<RespawnMessage>();
        _staticInstructionsScript = _staticInstructions.GetComponent<staticInstructions>();
        _instructionsTutorialScript = _instructionsTutorial.GetComponent<PlayerInstructionsInteractive>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // add instructions for game play
        Debug.Log("Game start");
        StartCoroutine(StartTutorial());
    }

    // Update is called once per frame
    void Update()
    {
        if (_dialogue._dialogueRunning == true || gameOverScene.gameOverActive == true || _respawnMessageScript._dialogueRunning == true)
        {
            _pauseMovement = true;
        }
        else
        {
            _pauseMovement = false;
        }

    }

    public void GameOver()
    {
        gameOverScene.Setup();
    }

    public void showInstructions()
    {
        _staticInstructionsScript.showInstructionsBox();
    }

    IEnumerator StartTutorial()
    {
        Debug.Log("Tutorial started");
        yield return new WaitForSeconds(2);
        _instructionsTutorial.SetActive(true);
        _instructionsTutorial.GetComponent<Image>().color = new Color(_instructionsTutorial.GetComponent<Image>().color.r, _instructionsTutorial.GetComponent<Image>().color.g, _instructionsTutorial.GetComponent<Image>().color.b, 240);
        _instructionsTutorialScript.StartInstructions();
    }

}
