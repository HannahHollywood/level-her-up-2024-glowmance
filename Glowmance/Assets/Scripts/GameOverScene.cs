using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public bool gameOverActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Setup()
    {
        Debug.Log("GameOver scene started");
        gameOverActive = true;
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        gameOverActive = false;
        SceneManager.LoadScene("CaveArea1");
    }

    public void ExitButton()
    {
        gameOverActive = false;
        SceneManager.LoadScene("MainMenu");
    }
}
