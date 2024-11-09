using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_script : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField]
    private string _horizontalAxis = "Horizontal", _verticalAxis = "Vertical";
    [SerializeField]

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Moving left and right
        float horizontalInput = Input.GetAxisRaw(_horizontalAxis);
        // Moving up and down
        float verticalInput = Input.GetAxisRaw(_verticalAxis);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Add jump
            rb2D.AddForce(transform.up * 500);
        }
    }
}
