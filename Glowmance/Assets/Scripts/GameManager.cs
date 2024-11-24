using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject endGame;
    public GameOverScene gameOverScene;

    void Awake()
    {
        gameOverScene = endGame.GetComponent<GameOverScene>();
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

    }
}
