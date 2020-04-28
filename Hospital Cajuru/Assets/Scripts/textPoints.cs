using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class textPoints : MonoBehaviour
{
    private TextMeshProUGUI pointText;

    // Start is called before the first frame update
    void Start()
    {
        pointText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = Points.instance.points.ToString();
    }
}
