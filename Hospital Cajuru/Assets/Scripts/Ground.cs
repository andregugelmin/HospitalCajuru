using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float yspeed;
    

    void Update()
    {
        transform.localPosition = new Vector3 (transform.position.x, transform.localPosition.y + yspeed * Time.deltaTime, transform.position.z);
        if (transform.position.y > 6.0f)
        {
            Destroy(gameObject);
        }

        yspeed = GameSpeed.instance.objSpeed;
    }
}
