using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

public class FirstStartManager : MonoBehaviour
{
    public GameObject ratePanel;
    public GameObject tutorialPanel;

    void Start()
    {
        Assets.SimpleLocalization.LocalizationManager.Read();
        Debug.Log(Application.systemLanguage);
        MobileAds.Initialize(initStatus => { });
        NetTime.Start();

        if (!PlayerPrefs.HasKey("Energy")) PlayerPrefs.SetInt("Energy", 10);

        if (!PlayerPrefs.HasKey("HeadSkins")) PlayerPrefs.SetString("HeadSkins", "0");
        if (!PlayerPrefs.HasKey("BodySkins")) PlayerPrefs.SetString("BodySkins", "0");
        if (!PlayerPrefs.HasKey("LegSkins")) PlayerPrefs.SetString("LegSkins", "0");
        if (!PlayerPrefs.HasKey("SelectedSkins")) PlayerPrefs.SetString("SelectedSkins", "0:0:0");

        if (!PlayerPrefs.HasKey("TopScore")) PlayerPrefs.SetInt("TopScore", 0);
        if (!PlayerPrefs.HasKey("Money")) PlayerPrefs.SetInt("Money", 0);
        if (!PlayerPrefs.HasKey("Tokens")) PlayerPrefs.SetInt("Tokens", 0);
        if (!PlayerPrefs.HasKey("MoneyHistory")) PlayerPrefs.SetString("MoneyHistory", "n;n;n;n;n");

        if (!PlayerPrefs.HasKey("StatEnemyCatch")) PlayerPrefs.SetInt("StatEnemyCatch", 0);
        if (!PlayerPrefs.HasKey("StatEnemyLost")) PlayerPrefs.SetInt("StatEnemyLost", 0);
        if (!PlayerPrefs.HasKey("StatMaxSpeed")) PlayerPrefs.SetInt("StatMaxSpeed", 0);
        if (!PlayerPrefs.HasKey("StatBarriers")) PlayerPrefs.SetInt("StatBarriers", 0);
        if (!PlayerPrefs.HasKey("StatAllMoney")) PlayerPrefs.SetInt("StatAllMoney", 0);
        if (!PlayerPrefs.HasKey("StatAllTokens")) PlayerPrefs.SetInt("StatAllTokens", 0);

        if (!PlayerPrefs.HasKey("GamesPlayed")) PlayerPrefs.SetInt("GamesPlayed", 0);
        if (!PlayerPrefs.HasKey("Rated")) PlayerPrefs.SetInt("Rated", -1);
        if (!PlayerPrefs.HasKey("SceneLaunch")) PlayerPrefs.SetInt("SceneLaunch", 0);
        PlayerPrefs.SetInt("SceneLaunch", PlayerPrefs.GetInt("SceneLaunch")+1);
        RateCheck();

        PlayerPrefs.Save();
    }

    private void RateCheck(){
        if (PlayerPrefs.GetInt("SceneLaunch") == 5){
            ratePanel.SetActive(true);
        }
        if (PlayerPrefs.GetInt("SceneLaunch") == 1){
            tutorialPanel.SetActive(true);
        } else Destroy(tutorialPanel);
    }
}
