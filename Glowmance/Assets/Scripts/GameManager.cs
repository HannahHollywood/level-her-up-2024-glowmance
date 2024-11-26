using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject endGame;
    public GameOverScene gameOverScene;
    public GameObject dialogueBox;
    Dialogue _dialogue;
    public bool _pauseMovement;

    void Awake()
    {
        gameOverScene = endGame.GetComponent<GameOverScene>();
        _dialogue = dialogueBox.GetComponent<Dialogue>();
    }
    public void GameOver()
    {
        Debug.Log("GameManager script started");
        gameOverScene.Setup();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_dialogue._dialogueRunning == true || gameOverScene.gameOverActive == true)
        {
            _pauseMovement = true;
        }
        else
        {
            _pauseMovement = false;
        }

    }
}
