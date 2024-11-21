using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
public class playerMovement : MonoBehaviour
{
    Rigidbody2D _rb2D;
    SpriteRenderer _sr;
    GameObject _tailGlow;
    GameObject _loveLetter;
    GameObject _loveLetterText;
    Animator _animator;
    public GameObject _dialogueBox;
    Dialogue _dialogueScript;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _jumpForce;
    [SerializeField] bool _isJumping;
    [SerializeField] bool _isLitAf;
    float _moveHorizontal;
    float _moveVertical;
    Vector3 _respawnPos;
    Vector3 _startPos;

    // Code runs before Start() method
    void Awake()
    {
        _dialogueBox = GameObject.FindGameObjectWithTag("dialogueBox");
        _dialogueScript = _dialogueBox.GetComponent<Dialogue>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb2D = gameObject.GetComponent<Rigidbody2D>();
        _sr = gameObject.GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _loveLetter = GameObject.FindWithTag("loveLetter");
        _loveLetterText = GameObject.FindWithTag("textLoveLetter");
        _tailGlow = GameObject.FindWithTag("TailGlow");
        _tailGlow.SetActive(true);
        _isLitAf = true;
        _isJumping = false;
        _moveSpeed = 2f;
        _jumpForce = 6f;
        _respawnPos = _loveLetter.transform.position;
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Moving left and right - below code will give a number of -1 for left, 0 for still, 1 for right
        _moveHorizontal = Input.GetAxisRaw("Horizontal");

        // Moving up and down
        _moveVertical = Input.GetAxisRaw("Vertical");
        // _rb2D.AddForce(xInput * speed, 0, zInput * speed);

        if (Input.GetKeyUp(KeyCode.F))
        {
            // tailGlow.SetActive(false);
            if (_isLitAf == true)
            {
                _tailGlow.SetActive(false);
                _isLitAf = false;
            }
            else
            {
                _tailGlow.SetActive(true);
                _isLitAf = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (_moveHorizontal > 0.1f || _moveHorizontal < -0.1f)
        {
            // vector2(left/right, y-axis), and then forcemode (some will add Time.Deltatime instead, but this is applied by default to ForceMode)
            _rb2D.AddForce(new Vector2(_moveHorizontal * _moveSpeed, 0f), ForceMode2D.Impulse);

            // If looking left, flip Lumina left, else if right, flip right
            if (_moveHorizontal < -0.1f)
            {
                _sr.flipX = false;
            }
            else
            {
                _sr.flipX = true;
            }
        }

        if (!_isJumping && _moveVertical > 0.1f)
        {
            // jump
            _rb2D.AddForce(new Vector2(0f, _moveVertical * _jumpForce), ForceMode2D.Impulse);
            // Sets the animator transition condition to active
            _animator.SetBool("Jump", true);
        }
        else
        {
            // Sets the animator transition condition to inactive
            _animator.SetBool("Jump", false);
        }

        // Sets the animator transition condition speed to match Lumina velocity
        _animator.SetFloat("Speed", Mathf.Abs(_rb2D.linearVelocityX));

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // When on ground, Lumina 'not jumping'
        if (collision.gameObject.tag == "Platform")
        {
            _isJumping = false;
        }

        // Lumina falls to her death / respawn
        if (collision.gameObject.tag == "fallDeath")
        {
            deathRespawn();
        }

        // Spider moves to Lumina if light is on
        // if (collision.gameObject.tag == "TailGlow" &&)

        // Spider kills Lumina / respawn
        if (collision.gameObject.tag == "spider" && _isLitAf == true)
        {
            deathRespawn();

            // ALT code: Lumina is destroyed
            // Destroy(gameObject);
        }

        // Lumina picks up love letter
        if (collision.gameObject.tag == "loveLetter")
        {
            // Letter object disappears
            _loveLetter.SetActive(false);

            // Open dialogue box
            StartCoroutine(LoveLetterTextPopup());

        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        // When not on ground, Lumina 'is jumping'
        if (collision.gameObject.tag == "Platform")
        {
            _isJumping = true;
        }
    }

    void deathRespawn()
    {
        // TO DO create text with 'Dead' message and maybe a pause to make respawn less jarring

        // If love letter has been collected
        if (_loveLetter.activeSelf == false)
        {
            // Respawn at love letter checkpoint
            transform.position = _respawnPos;
        }
        else
        {
            // Respawn at start
            transform.position = _startPos;
        }
    }

    IEnumerator LoveLetterTextPopup()
    {
        Debug.Log("coroutine started");
        // Wait 2 sedonds
        yield return new WaitForSeconds(2);
        // Show dialogue box
        _dialogueBox.SetActive(true);
        // Run dialogue script
        _dialogueScript.StartDialogue();
    }
}

