using UnityEngine;

public class staticInstructions : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showInstructionsBox()
    {

        if (gameObject.activeSelf == false)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}

// <b>Controls</b>
// <br>
// <color=#C2CB5C> Left Arrow </color=#C2CB5C>or <color=#C2CB5C>  'a' key </color=#C2CB5C>- Move left
// <br>
// <color=#C2CB5C> Right Arrow </color=#C2CB5C>or <color=#C2CB5C>  'd' key </color=#C2CB5C>- Move right
// <br>
// <color=#C2CB5C> Up Arrow </color=#C2CB5C> or <color=#C2CB5C>  'w' key </color=#C2CB5C> - Jump
// <br>
// <color=#C2CB5C>  'f' key </color=#C2CB5C> - Toggle glow tail light on and off