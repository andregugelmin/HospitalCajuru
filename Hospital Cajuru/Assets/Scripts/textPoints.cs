using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class textPoints : MonoBehaviour
{
    
    public TextMeshProUGUI pointText;
  


    // Start is called before the first frame update
    void Start()
    {
        Points.instance.points = 0;
        pointText = gameObject.GetComponent<TextMeshProUGUI>();
        Points.instance.points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = Points.instance.points.ToString("F0");
        
    }
}
