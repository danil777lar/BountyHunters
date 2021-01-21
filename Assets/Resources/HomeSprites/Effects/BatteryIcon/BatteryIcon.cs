using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryIcon : MonoBehaviour
{
    private int lastState;
    void Start()
    {
        int energy = EnergyManager.GetEnergyVolume();
        lastState = energy;
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("HomeSprites/Effects/BatteryIcon/"+energy);
    }

    void Update()
    {
        if (EnergyManager.GetEnergyVolume() != lastState) Start();
    }
}
