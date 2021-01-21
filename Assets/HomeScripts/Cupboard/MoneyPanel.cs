using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyPanel : MonoBehaviour
{
    public void Start()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        texts[0].text = ""+PlayerPrefs.GetInt("Money")+"C";
        texts[1].text = ""+PlayerPrefs.GetInt("Tokens")+"T";
    }
}
