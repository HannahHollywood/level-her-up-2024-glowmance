using UnityEngine;

public class spiderBehaviour : MonoBehaviour
{
    Animator _spiderAnimate;
    Rigidbody2D _rb2Dspider;
    GameObject _lumina;
    Vector3 _luminaPos;
    Vector3 _startPos;
    GameObject _luminaLight;
    [SerializeField] bool _luminaNear;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _spiderAnimate = gameObject.GetComponent<Animator>();
        _rb2Dspider = gameObject.GetComponent<Rigidbody2D>();
        _lumina = GameObject.FindGameObjectWithTag("Player");
        _startPos = transform.position;
        _luminaPos = _lumina.transform.position;
        _luminaLight = GameObject.FindGameObjectWithTag("TailGlow");
        _luminaNear = true; // TO DO need to make this dynamic
    }

    // Update is called once per frame
    void Update()
    {
        // Set Animator bool true for if Lumina light is on
        if (_luminaLight.activeSelf == true)
        {
            _spiderAnimate.SetBool("isLight", true);
        }
        else
        {
            _spiderAnimate.SetBool("isLight", false);
        }

        // Set Animator bool true for if Lumina near spider
        if (_luminaNear == true)
        {
            _spiderAnimate.SetBool("isNearLumina", true);
        }
        else
        {
            _spiderAnimate.SetBool("isNearLumina", false);
        }

        // TO DO - make this work 
        // if (_luminaNear == true && _luminaLight.activeSelf == true)
        // {
        //     // move spider towards Lumina
        //     _rb2Dspider.AddForce(new Vector2(_luminaPos.x, _luminaPos.y), ForceMode2D.Impulse);
        // }
        // else
        // {   // move spider back to start position
        //     _rb2Dspider.AddForce(new Vector2(_startPos.x, _startPos.y), ForceMode2D.Impulse);
    }
}
