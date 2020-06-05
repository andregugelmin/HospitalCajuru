using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class textPoints : MonoBehaviour
{
    public float points = 0.0f;
    public TextMeshProUGUI pointText;
   

    // Start is called before the first frame update
    void Start()
    {
        pointText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = points.ToString("F0");
        points += Time.deltaTime;
    }
}
