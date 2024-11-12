using TMPro;
using UnityEngine;

public class TextFade : MonoBehaviour
{
    public float fadeTime;
    private TextMeshProUGUI loveLetterText;
    private float alphaValue;
    private float fadeAwayPerSecond;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        loveLetterText = gameObject.GetComponent<TextMeshProUGUI>();
        fadeAwayPerSecond = 1 / fadeTime;
        alphaValue = loveLetterText.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeTime > 0)
        {
            alphaValue -= fadeAwayPerSecond * Time.deltaTime;
            loveLetterText.color = new Color(loveLetterText.color.r, loveLetterText.color.g, loveLetterText.color.b, alphaValue);
            fadeTime -= Time.deltaTime;
        }

    }
}
