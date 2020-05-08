using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float yPos;
    private float yspeed;
    private float offset;
    [SerializeField]
    private GameObject SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        yPos = transform.position.y;
        yspeed = 0.5f;
        Debug.Log(SpriteRenderer.transform.GetComponent<SpriteRenderer>().bounds.size.y);
    }

    // Update is called once per frame
    void Update()
    {
        yPos += yspeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, yPos);
        if(yPos >= 12f)
        {
            
            yPos -= (SpriteRenderer.transform.GetComponent<SpriteRenderer>().bounds.size.y*2) ;
        }
        if (Points.instance.points >= 100 && yspeed < 1f)
        {
            yspeed = 1f;
        }
        if (Points.instance.points >= 300 && yspeed < 1.5f)
        {
            yspeed = 1.5f;
        }
        if (Points.instance.points >= 500 && yspeed < 2f)
        {
            yspeed = 2f;
        }
        if (Points.instance.points >= 800 && yspeed < 2.5f)
        {
            yspeed = 2.5f;
        }
    }
}
