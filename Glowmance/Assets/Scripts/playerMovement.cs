using UnityEngine;
public class playerMovement : MonoBehaviour
{
    public Rigidbody2D _rb2D;
    GameObject tailGlow;
    GameObject loveLetter;
    public Animator luminaMove;
    public float moveSpeed;
    public float jumpForce;
    bool isJumping;
    float moveHorizontal;
    float moveVertical;
    public bool isLitAf;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb2D = gameObject.GetComponent<Rigidbody2D>();
        luminaMove = GetComponent<Animator>();
        loveLetter = GameObject.FindWithTag("loveLetter");
        tailGlow = GameObject.FindWithTag("TailGlow");
        tailGlow.SetActive(true);
        isLitAf = true;
        isJumping = false;
        moveSpeed = 3f;
        // jumpForce = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        // Moving left and right - below code will give a number of -1 for left, 0 for still, 1 for right
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        // Moving up and down
        moveVertical = Input.GetAxisRaw("Vertical");
        // _rb2D.AddForce(xInput * speed, 0, zInput * speed);
        if (Input.GetKeyUp(KeyCode.F))
        {
            // tailGlow.SetActive(false);
            if (isLitAf == true)
            {
                tailGlow.SetActive(false);
                isLitAf = false;
            }
            else
            {
                tailGlow.SetActive(true);
                isLitAf = true;
            }
        }

    }

    void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            // vector2(left/right, y-axis), and then forcemode (some will add Time.Deltatime instead, but this is applied by default to ForceMode)
            _rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }
        if (!isJumping && moveVertical > 0.1f)
        {
            // jump
            _rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
        }
        // Debug.Log(_rb2D.linearVelocityX);
        luminaMove.SetFloat("Speed", Mathf.Abs(_rb2D.linearVelocityX));
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }

        if (collision.gameObject.tag == "loveLetter")
        {
            // letter object is destroyed
            Destroy(collision.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
}