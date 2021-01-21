using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatePanel : MonoBehaviour, IPanel
{
    private int rate;

    public Image dogeImage;
    public Sprite strong;
    public Sprite sad;

    public bool IsActive(){
        return gameObject.active;
    }

    private void Start(){

    }

    public void StarClicked(int rate){
        this.rate = rate;
        Button[] stars = GetComponentsInChildren<Button>();
        for (int i = 0; i <= rate; i++){
            stars[i].gameObject.GetComponent<Animator>().Play("Base Layer.Rate");
        }
        if (rate < 3) dogeImage.sprite = sad;
        else dogeImage.sprite = strong;
        Invoke("NextWindow", .35f);
    }

    private void NextWindow(){
        GetComponent<Animator>().Play("Base Layer.NextFrame");
        if (rate < 3) GetComponentInChildren<Text>().text = Assets.SimpleLocalization.LocalizationManager.Localize("Rate.PostRateBad");
        else GetComponentInChildren<Text>().text = Assets.SimpleLocalization.LocalizationManager.Localize("Rate.PostRateGood");
    }


    public void LaterButton(){
        PlayerPrefs.SetInt("Rate", rate+1);
        // gameObject.SetActive(false);
        GetComponent<Animator>().Play("Close.Close");
        Invoke("Close", 0.5f);
    }

    public void OkButton(){
        PlayerPrefs.SetInt("Rate", rate+1);
        Application.OpenURL("market://details?id="+Application.identifier);
        GetComponent<Animator>().Play("Close.Close");
        Invoke("Close", 0.5f);
    }

    private void Close(){
        gameObject.SetActive(false);
    }

}
