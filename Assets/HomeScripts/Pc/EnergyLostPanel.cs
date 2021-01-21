using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyLostPanel : MonoBehaviour
{
    private SuspectButton suspectButton;

    void Start(){
        if (!NetTime.isWorking){
            GetComponentInChildren<Text>().text = Assets.SimpleLocalization.LocalizationManager.Localize("PC.Hunt.PlayPanelTitleNoNet");
            GetComponentInChildren<Button>().gameObject.SetActive(false);
        }
    }

    public void BindButton(SuspectButton suspectButton){
        this.suspectButton = suspectButton;
    }

    public void OkPressed(){
        if (MoneyManager.SpendTokens(1)){
            PlayerPrefs.SetInt("Energy", 10);
            Invoke("Close", .3f);
            GetComponentInParent<Animator>().Play("PanelsLayer.CloseNoEnergy");
        } else {
            GetComponentInChildren<Text>().text = Assets.SimpleLocalization.LocalizationManager.Localize("PC.Hunt.PlayPanelTitleNoEnergyFalse");
            GetComponentInChildren<Button>().gameObject.SetActive(false);
        }
        
    }

    public void CancelPressed(){
        Invoke("Close", .3f);
        GetComponentInParent<Animator>().Play("PanelsLayer.CloseNoEnergy");
    }

    private void Close(){
        gameObject.SetActive(false);
    }
}
