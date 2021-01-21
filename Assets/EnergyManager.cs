using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class EnergyManager
{
    public static int EnergyRegTime = 10; 

    public static int GetEnergyVolume(){
        if (!NetTime.isWorking) return -1;
        if (PlayerPrefs.GetInt("Energy") < 10){
            long secondsPassed = (NetTime.Get().Ticks/System.TimeSpan.TicksPerSecond) -  long.Parse(PlayerPrefs.GetString("EnergyLastChange"));
            if (secondsPassed >= EnergyRegTime*60){
                int energy =  PlayerPrefs.GetInt("Energy");
                energy += Mathf.FloorToInt(secondsPassed/EnergyRegTime*60);
                if (energy > 10) energy = 10;
                PlayerPrefs.SetInt("Energy",energy);
                PlayerPrefs.SetString("EnergyLastChange",""+(NetTime.Get().Ticks/System.TimeSpan.TicksPerSecond));
                PlayerPrefs.Save();
            }
        }
        return PlayerPrefs.GetInt("Energy");
    }

    public static bool SpendEnergy(){
        if (GetEnergyVolume() > 0 && NetTime.Get() != null){
            PlayerPrefs.SetInt("Energy", PlayerPrefs.GetInt("Energy")-1);
            PlayerPrefs.SetString("EnergyLastChange",""+(NetTime.Get().Ticks/System.TimeSpan.TicksPerSecond));
            PlayerPrefs.Save();
            return true;
        } else return false;
    }
}
