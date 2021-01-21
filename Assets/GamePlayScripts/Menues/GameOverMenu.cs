using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour, IAdCreator
{
    public ScoreCounter scoreCounter;
    public RewardedAdGenerator rewAd;
    public InterstitialAdGenerator intAd;

    private Button adButton;
    private Slider slider;
    private bool isWinning;

    private float sliderStartTime = -1f;
    private float sliderFullTime = 4f;

    private int moneyScale = 1;

    private bool isStandartAd = false;


    void Update(){
        if (slider.value > 0) slider.value = 1f-((Time.time - sliderStartTime)/3f);
        else if (adButton.gameObject.active) adButton.gameObject.SetActive(false);
    }

    public void GameWin(){
        isWinning = true;
        Text[] textFields = GetComponentsInChildren<Text>();
        try{
            StartSlider();
            adButton.GetComponentInChildren<Text>().text = Assets.SimpleLocalization.LocalizationManager.Localize("Over.Double");
        }catch{}
        Button exitButton = GetComponentInChildren<Button>(); 
        Color color = new Color(0.9019608f, 0.9333333f, 0.6117647f); 
        exitButton.gameObject.GetComponentInChildren<Image>().color = color;
        textFields[0].text = Assets.SimpleLocalization.LocalizationManager.Localize("Over.Success");
        textFields[0].color = color;
        textFields[2].text = ""+(scoreCounter.GetScore()*moneyScale)+"C";
        if (EnemyConstructor.isToken){
            textFields[4].text = ""+(EnemyConstructor.cost*moneyScale)+"T";
            textFields[6].text = ""+(scoreCounter.GetScore()*moneyScale)+"C "+(EnemyConstructor.cost*moneyScale)+"T";
        } else {
            textFields[4].text = ""+(EnemyConstructor.cost*moneyScale)+"C";
            textFields[6].text = ""+((scoreCounter.GetScore()+EnemyConstructor.cost)*moneyScale)+"C";
        }
    }

    public void GameLose(){
        isWinning = false;
        try{
            StartSlider();
            adButton.GetComponentInChildren<Text>().text = Assets.SimpleLocalization.LocalizationManager.Localize("Over.Extra");
        }catch{}
        Text[] textFields = GetComponentsInChildren<Text>();
        textFields[0].text = Assets.SimpleLocalization.LocalizationManager.Localize("Over.Fail");
        textFields[2].text = ""+scoreCounter.GetScore()+"C";
         if (EnemyConstructor.isToken){
            textFields[4].text = "0T";
            textFields[6].text = ""+scoreCounter.GetScore()+"C 0T";
        } else {
            textFields[4].text = "0C";
            textFields[6].text = ""+scoreCounter.GetScore()+"C";
        }
    }

    private void StartSlider(){
        slider = GetComponentInChildren<Slider>();
        adButton = slider.gameObject.GetComponentInParent<Button>();
        slider.value = 1f;
        sliderStartTime = Time.time;
    }

    // public void RestartButtonClicked(){
    //     Time.timeScale = 1f;
    //     if (!LevelConstructor.isFreeMode){
    //         if (EnergyManager.SpendEnergy()){
    //             SaveScore();
    //             Application.LoadLevel("Scenes/SampleScene");
    //         } else {
        
    //         }
    //     } else {
    //         SaveScore();
    //         Application.LoadLevel("Scenes/SampleScene");
    //     }
    // }

    public void ExitButtonClicked(){
        Time.timeScale = 1f;
        isStandartAd = true;
        if (Random.Range(0, 2) == 0) Exit();
        else intAd.Show(this);
    }

    void Exit(){
        PlayerPrefs.SetInt("GamesPlayed", PlayerPrefs.GetInt("GamesPlayed")+1);
        PlayerPrefs.Save();
        SaveScore();
        Application.LoadLevel("Scenes/MainScene");
    }

     private void SaveScore(){
        int money = scoreCounter.GetScore();
        int tokens = 0;
        if (isWinning){
            if (EnemyConstructor.isToken) tokens = EnemyConstructor.cost;
            else money += EnemyConstructor.cost;
        }
        MoneyManager.EarnMoney(money*moneyScale);
        MoneyManager.EarnTokens(tokens*moneyScale);
        if (PlayerPrefs.GetInt("TopScore") < scoreCounter.GetScore()){
            PlayerPrefs.SetInt("TopScore", scoreCounter.GetScore());
        }
        int speed = Mathf.FloorToInt(scoreCounter.gameObject.GetComponent<LevelModuleMoving>().oldSpeed);
        if (speed > PlayerPrefs.GetInt("StatMaxSpeed")) PlayerPrefs.SetInt("StatMaxSpeed", speed);
        PlayerPrefs.SetInt("StatBarriers", PlayerPrefs.GetInt("StatBarriers")+scoreCounter.GetScore());
        if (!LevelConstructor.isFreeMode){
            if (isWinning) PlayerPrefs.SetInt("StatEnemyCatch", PlayerPrefs.GetInt("StatEnemyCatch")+1);
            else PlayerPrefs.SetInt("StatEnemyLost", PlayerPrefs.GetInt("StatEnemyLost")+1);
        }
    }

    public void AdButtonClicked(){
        isStandartAd = false;
        rewAd.Show(this);
        adButton.gameObject.SetActive(false);
    }

    public void RewAdClosed(){
        if (isWinning) {
            moneyScale = 2;
            GameWin();
        } else {
            LevelModuleMoving lmm = scoreCounter.gameObject.GetComponent<LevelModuleMoving>();
            lmm.speed = lmm.oldSpeed;
            lmm.isGameOver = false;
            lmm.isMoving = true;
            gameObject.SetActive(false);
        }
    }

    public void IntAdClosed(){
        Exit();
    }
}
