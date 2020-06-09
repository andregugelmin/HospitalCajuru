using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{

    public static Points instance { get; private set; }
    public float points, finalPoints;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        points = 0;
    }
    private void Update()
    {
        points += Time.deltaTime;
    }

    
}
