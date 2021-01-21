using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryClock : MonoBehaviour
{
    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        int vol = EnergyManager.GetEnergyVolume();
        if (vol > 9 || vol == -1) text.text = "";
        else{
            long secondsPassed = (NetTime.Get().Ticks/System.TimeSpan.TicksPerSecond) -  long.Parse(PlayerPrefs.GetString("EnergyLastChange"));
            long secondsToAdd = (EnergyManager.EnergyRegTime*60) - secondsPassed; 
            int minutes = Mathf.FloorToInt(secondsToAdd/60);
            long seconds = secondsToAdd - (minutes*60);
            string secondsString = ""+seconds;
            if (secondsString.Length < 2) secondsString = "0"+secondsString;
            text.text = ""+minutes+":"+secondsString;
        }
    }
}
