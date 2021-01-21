using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonatePanel : MonoBehaviour
{
    Animator animator;
    public BankPanel bankPanel;

    void Start(){
        animator = GetComponent<Animator>();
    }

    public void ClosePanel(){
        animator.Play("Base Layer.Close");
        Invoke("CloseInvoke", 0.5f);
    }
    private void CloseInvoke(){
        gameObject.SetActive(false);
    }

    public void OpenPanel(){
        gameObject.SetActive(true);
        if (animator == null) Start();
        animator.Play("Base Layer.Open");
    }

    public void UpdateBank(){
        bankPanel.UpdatePanel();
    }
    
}
