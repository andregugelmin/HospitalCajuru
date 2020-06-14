using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private Vector3 startTouchPosition;
    [SerializeField]
    private Vector3 currentTouchPosition;
    [SerializeField]
    private float xSpeed;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    [SerializeField]
    private GameObject SpriteRenderer;
    [SerializeField]
    private GameObject SpriteRenderer2;
    private int timeBoost;
    public AudioClip sound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = SpriteRenderer.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = SpriteRenderer.transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameSpeed.instance.gameState)
        {            
            case GameSpeed.GameState.waitingBoost:
                
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:                            
                            break;
                       
                        case TouchPhase.Ended:
                            GameSpeed.instance.timeBoosted = timeBoost;
                            break;
                    }
                }
                break;
            default:
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                            startTouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                            currentTouchPosition = startTouchPosition;
                            break;
                        case TouchPhase.Moved:
                            currentTouchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                            transform.position = new Vector3((currentTouchPosition.x - startTouchPosition.x) * xSpeed, 2.2f, 0);
                            break;
                        case TouchPhase.Stationary:
                            currentTouchPosition = startTouchPosition;
                            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                            break;
                        case TouchPhase.Ended:
                            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                            break;
                    }
                }
                break;
        }

        
        
        
            
    }

    void LateUpdate()
    {
        Vector3 objectPosition = transform.position;
        objectPosition.x = Mathf.Clamp(objectPosition.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);
        objectPosition.y = Mathf.Clamp(objectPosition.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight);
        transform.position = objectPosition;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground" && GameSpeed.instance.gameState == GameSpeed.GameState.normal)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Points.instance.finalPoints = Points.instance.points;
            source.PlayOneShot(sound);
        }

        if(collision.gameObject.tag == "Cloud")
        {
            GameSpeed.instance.gameState = GameSpeed.GameState.waitingBoost;
            collision.gameObject.GetComponent<Animator>().SetBool("isWaitingBoost", true);
            SpriteRenderer.SetActive(false);
            SpriteRenderer2.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cloud")
        {
            timeBoost = collision.gameObject.GetComponent<Cloud>().timeBoost;
            Debug.Log(timeBoost);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cloud")
        {            
            collision.gameObject.GetComponent<Animator>().SetBool("isWaitingBoost", false);
            SpriteRenderer.SetActive(true);
            SpriteRenderer2.SetActive(true);
        }
    }
}
