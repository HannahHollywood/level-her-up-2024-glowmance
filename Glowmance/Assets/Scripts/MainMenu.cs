using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayButton()
    {
        SceneManager.LoadScene("CaveArea1");
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }
}
