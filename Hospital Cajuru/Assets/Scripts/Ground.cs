using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float yspeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3 (transform.position.x, transform.localPosition.y + yspeed * Time.deltaTime, transform.position.z);
        if (transform.position.y > 6.0f)
        {
            Destroy(gameObject);
        }

        if(Points.instance.points >= 100 && yspeed < 2)
        {
            yspeed = 2;
        }
        if (Points.instance.points >= 300 && yspeed < 3)
        {
            yspeed = 3;
        }
        if (Points.instance.points >= 500 && yspeed < 4)
        {
            yspeed = 4;
        }
        if (Points.instance.points >= 800 && yspeed < 5)
        {
            yspeed = 5;
        }
    }
}
