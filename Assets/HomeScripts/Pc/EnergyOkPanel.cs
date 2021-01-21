using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyOkPanel : MonoBehaviour
{
    private SuspectButton suspectButton;

    public void BindButton(SuspectButton suspectButton){
        this.suspectButton = suspectButton;
    }

    public void OkPressed(){
        suspectButton.StartGame();
    }

    public void CancelPressed(){
        Invoke("Close", .3f);
        GetComponentInParent<Animator>().Play("PanelsLayer.CloseOkPanel");
    }

    private void Close(){
        gameObject.SetActive(false);
    }
}
