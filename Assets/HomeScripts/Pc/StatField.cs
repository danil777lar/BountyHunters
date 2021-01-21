using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatField : MonoBehaviour
{
    public string fieldName;

    public void Start()
    {
        GetComponent<Text>().text = ""+PlayerPrefs.GetInt("Stat"+fieldName);    
    }
}
