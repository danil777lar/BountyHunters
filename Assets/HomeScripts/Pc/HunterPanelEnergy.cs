using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HunterPanelEnergy : MonoBehaviour
{
    private bool hasConnection = true;
    Text text;


    void Start()
    {
        text = GetComponent<Text>();
        text.text = "";
        if (EnergyManager.GetEnergyVolume() == -1)hasConnection = false;
        else GetComponentInChildren<Image>().gameObject.SetActive(false);


    }

    void Update()
    {
        if (hasConnection) text.text = EnergyManager.GetEnergyVolume()+"/10";
    }
}
