using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SkinsInfo
{
    public static int[] headCost = {0, 1000, 1500, 2000, 2000};
    public static int[] bodyCost = {0, 1000, 1500, 2000, 2000};
    public static int[] legCost = {0, 1000, 1500, 2000, 2000};
    public static bool[] isTokens = {false, false, false, false, false};

    public static string GetName(string bodyPart, int id){
        return Assets.SimpleLocalization.LocalizationManager.Localize("Skins."+id+"."+bodyPart);
    }

    public static int[] GetCost(string bodyPart){
        switch(bodyPart){
            case "Head":
                return headCost;
            break;
            case "Body":
                return bodyCost;
            break;
            case "Leg":
                return legCost;
            break;
        }
        return null;
    }
}
