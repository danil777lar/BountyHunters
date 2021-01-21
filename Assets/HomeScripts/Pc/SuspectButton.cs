using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspectButton : MonoBehaviour
{
    public GameObject okPanel;
    public GameObject noPanel;


    public Image headImage;
    public Image bodyImage;

    public Text delo;
    public Text danger;
    public Text cost;

    private int dangerInt;
    private int costInt;
    private int speedInt;

    private int headId;
    private int bodyId;
    private int legId;

    private bool isToken = false;


    public void CreatePanel(int panelNum){
        MakeImage();
        MakeText();
    }

    void MakeImage(){
        headId = Random.Range(0, SkinsInfo.GetCost("Head").Length);
        bodyId = Random.Range(0, SkinsInfo.GetCost("Body").Length);
        legId = Random.Range(0, SkinsInfo.GetCost("Leg").Length);

        headImage.sprite = Resources.Load<Sprite>("Sprites/Hairs/"+headId+"/0");
        bodyImage.sprite = Resources.Load<Sprite>("Sprites/Arms/"+bodyId+"/0");
    }

    void MakeText(){
        isToken = false;
        delo.text = "№"+Random.Range(11111, 99999);
        dangerInt = Random.Range(1, 4);
        switch (dangerInt){
            case 1:
                speedInt = Random.Range(12, 16); 
                costInt = Random.Range(100, 501);
            break;
            case 2:
                speedInt = Random.Range(16, 21); 
                costInt = Random.Range(500, 1001);
            break;
            case 3:
                speedInt = Random.Range(21, 25); 
                costInt = Random.Range(1000, 2501);
                if (costInt > 2000){
                    isToken = true;
                    costInt = 1;
                }
            break;
        } 
        danger.text = ""+speedInt+" "+Assets.SimpleLocalization.LocalizationManager.Localize("Global.Speed");
        if (isToken) cost.text = ""+costInt+"T";
        else cost.text = ""+costInt+"C";
    }

    public void ButtonClicked(){
        if (EnergyManager.GetEnergyVolume() > 0){
            okPanel.SetActive(true);
            okPanel.GetComponent<EnergyOkPanel>().BindButton(this);
        } else {
            noPanel.SetActive(true);
            noPanel.GetComponent<EnergyLostPanel>().BindButton(this);
        }
    }

    public void StartGame(){
        LevelConstructor.cost = costInt;
        LevelConstructor.hardLevel = dangerInt;
        LevelConstructor.isFreeMode = false;
        EnergyManager.SpendEnergy();
        EnemySkinConstructor.headId = headId;
        EnemySkinConstructor.bodyId = bodyId;
        EnemySkinConstructor.legId = legId;
        EnemyConstructor.isToken = isToken;
        // 
        EnemyConstructor.maxSpeed = speedInt;
        // EnemyConstructor.maxSpeed = 12;
        // 
        EnemyConstructor.cost = costInt;
        Application.LoadLevel("Scenes/SampleScene");
    }


    
}
