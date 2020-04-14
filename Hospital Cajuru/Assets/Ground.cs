using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField]
    private float yspeed;
    
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
    }
}
