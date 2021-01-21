using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class BuyButton : MonoBehaviour
{
    public int productCount;
    public bool isToken;

    public void PurchaseAccept(){
        if (isToken) MoneyManager.EarnTokens(productCount);
        else MoneyManager.EarnMoney(productCount);
        GetComponentInParent<DonatePanel>().UpdateBank();
    }
}
