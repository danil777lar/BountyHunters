using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealTime : MonoBehaviour
{
    private Text textField;

    void Start()
    {
        textField = GetComponent<Text>();
    }

    void Update()
    {
        string hour =  ""+System.DateTime.Now.Hour;
        string minutes = ""+System.DateTime.Now.Minute;

        if (hour.Length < 2) hour = "0"+hour;
        if (minutes.Length < 2) minutes = "0"+minutes;
        
        textField.text = ""+hour+":"+minutes;
    }
}
