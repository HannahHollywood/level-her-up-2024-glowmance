using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Setup()
    {
        Debug.Log("GameOver scene started");
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("MainGlowwormCave");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
