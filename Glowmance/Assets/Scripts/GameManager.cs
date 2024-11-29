using UnityEngine;
using UnityEngine.UI;

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
    public bool _pauseMovement;

    void Awake()
    {
        gameOverScene = endGame.GetComponent<GameOverScene>();
        _dialogue = dialogueBox.GetComponent<Dialogue>();
        _respawnMessageScript = respawnMessage.GetComponent<RespawnMessage>();
        _staticInstructionsScript = _staticInstructions.GetComponent<staticInstructions>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // add instructions for game play
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

}
