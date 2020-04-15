using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    transform.position = new Vector3((currentTouchPosition.x - startTouchPosition.x)*xSpeed, 0, 0);
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
        
        
            
    }

    void LateUpdate()
    {
        Vector3 objectPosition = transform.position;
        objectPosition.x = Mathf.Clamp(objectPosition.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);
        objectPosition.y = Mathf.Clamp(objectPosition.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight);
        transform.position = objectPosition;
    }


}
