using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MoneyManager
{
    public static void EarnMoney(int earnSum){
        int playerMoney = PlayerPrefs.GetInt("Money");
        PlayerPrefs.SetInt("Money", playerMoney+earnSum);
        string[] oldOperations = PlayerPrefs.GetString("MoneyHistory").Split(';');
        string[] newOperations = new string[5];
        string hours = ""+System.DateTime.Now.Hour;
        string minute = ""+System.DateTime.Now.Minute;
        if (hours.Length < 2) hours = "0"+hours;
        if (minute.Length < 2) minute = "0"+minute;
        newOperations[0] = "+"+earnSum+":"+hours+minute;
        for (int i = 1; i < 5; i++){
            newOperations[i] = oldOperations[i-1];
        }
        PlayerPrefs.SetString("MoneyHistory", newOperations[0]+";"+newOperations[1]+";"+newOperations[2]+";"+newOperations[3]+";"+newOperations[4]);
        PlayerPrefs.SetInt("StatAllMoney", PlayerPrefs.GetInt("StatAllMoney")+earnSum);
        PlayerPrefs.Save();
    }

    public static bool SpendMoney(int spendSum){
        int playerMoney = PlayerPrefs.GetInt("Money");
        if (spendSum > playerMoney) return false;
        PlayerPrefs.SetInt("Money", playerMoney-spendSum);
        string[] oldOperations = PlayerPrefs.GetString("MoneyHistory").Split(';');
        string[] newOperations = new string[5];
        string hours = ""+System.DateTime.Now.Hour;
        string minute = ""+System.DateTime.Now.Minute;
        if (hours.Length < 2) hours = "0"+hours;
        if (minute.Length < 2) minute = "0"+minute;
        newOperations[0] = "-"+spendSum+":"+hours+minute;
        for (int i = 1; i < 5; i++){
            newOperations[i] = oldOperations[i-1];
        }
        PlayerPrefs.SetString("MoneyHistory", newOperations[0]+";"+newOperations[1]+";"+newOperations[2]+";"+newOperations[3]+";"+newOperations[4]);
        PlayerPrefs.Save();
        return true;
    }

    public static void EarnTokens(int sum){
        PlayerPrefs.SetInt("Tokens", PlayerPrefs.GetInt("Tokens")+sum);
        PlayerPrefs.SetInt("StatAllTokens", PlayerPrefs.GetInt("StatAllTokens")+sum);
        PlayerPrefs.Save();
    }

    public static bool SpendTokens(int sum){
        int playerTokens = PlayerPrefs.GetInt("Tokens");
        if (sum > playerTokens) return false;
        PlayerPrefs.SetInt("Tokens", playerTokens - sum);
        PlayerPrefs.Save();
        return true;
    }
}
