using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public ScoreCounter scoreCounter;
    public LevelModuleMoving lm;

    public void Open(){
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        Text[] textFields = GetComponentsInChildren<Text>();
        Debug.Log(""+textFields.Length);
        textFields[0].text = Assets.SimpleLocalization.LocalizationManager.Localize("Pause.Speed")+": "+lm.speed+Assets.SimpleLocalization.LocalizationManager.Localize("Global.Speed");
        textFields[1].text = Assets.SimpleLocalization.LocalizationManager.Localize("Pause.MaxSpeed")+": "+EnemyConstructor.maxSpeed+Assets.SimpleLocalization.LocalizationManager.Localize("Global.Speed");
        textFields[2].text = Assets.SimpleLocalization.LocalizationManager.Localize("Pause.Score")+": "+scoreCounter.GetScore();
        textFields[3].text = Assets.SimpleLocalization.LocalizationManager.Localize("Pause.Money")+": "+scoreCounter.GetScore()+"C";
    }

    public void ContinueButtonClicked(){
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }

    // public void RestartButtonClicked(){
    //     Time.timeScale = 1f;
    //     if (!LevelConstructor.isFreeMode){
    //         if (EnergyManager.SpendEnergy()){
    //             SaveScore();
    //             Application.LoadLevel("Scenes/SampleScene");
    //         } else {
    //             
    //         }
    //     } else {
    //         SaveScore();
    //         Application.LoadLevel("Scenes/SampleScene");
    //     }
    // }

    public void ExitButtonClicked(){
        Time.timeScale = 1f;
        SaveScore();
        Application.LoadLevel("Scenes/MainScene");
    }

    private void SaveScore(){
        MoneyManager.EarnMoney(scoreCounter.GetScore());
        if (PlayerPrefs.GetInt("TopScore") < scoreCounter.GetScore()){
            PlayerPrefs.SetInt("TopScore", scoreCounter.GetScore());
        }
    }
}
