using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcceptButton : MonoBehaviour
{
    private int itemId;
    private string bodyPart;
    private int bodyPartInt;
    private bool isBought;
    private bool isSelected;

    private ItemButton itemButton;

    void Start()
    {  
        GetComponent<Image>().color = new Color(0,0,0,0);
        GetComponentInChildren<Text>().color = new Color(0,0,0,0);
    }

    public void GenerateButton(int itemId, string bodyPart, bool isBought, ItemButton itemButton){
        this.itemId = itemId;
        this.bodyPart = bodyPart;
        this.isBought = isBought;
        this.itemButton = itemButton;
        switch (bodyPart){
            case "Head":
                bodyPartInt = 0;
            break;
            case "Body":
                bodyPartInt = 1;
            break;
            case "Leg":
                bodyPartInt = 2;
            break;
        }

        if (int.Parse(PlayerPrefs.GetString("SelectedSkins").Split(':')[bodyPartInt]) == itemId) isSelected = true;
        else isSelected = false;

        string buttonText = "";
        GetComponent<Button>().interactable = true;
        if (!isBought){
            buttonText = ""+SkinsInfo.GetCost(bodyPart)[itemId];
            if (!SkinsInfo.isTokens[itemId]) buttonText += "C";
            else buttonText += "T";
        }
        else if (!isSelected) buttonText = Assets.SimpleLocalization.LocalizationManager.Localize("Cupboard.Choose");
        else{
            buttonText = Assets.SimpleLocalization.LocalizationManager.Localize("Cupboard.Choosed");
            GetComponent<Button>().interactable = false;
        }

        GetComponent<Image>().color = new Color(1,1,1,1);
        GetComponentInChildren<Text>().color = new Color(0,0,0,1);
        GetComponentInChildren<Text>().text = buttonText;
    }

    public void ButtonClicked(){
        if (isBought && !isSelected){
            string[] selectedSkins = PlayerPrefs.GetString("SelectedSkins").Split(':');
            selectedSkins[bodyPartInt] = ""+itemId;
            PlayerPrefs.SetString("SelectedSkins", ""+selectedSkins[0]+":"+selectedSkins[1]+":"+selectedSkins[2]);
            PlayerPrefs.Save();
            itemButton.MakeSelected();
            GenerateButton(itemId, bodyPart, isBought, itemButton);
        } else if (!isBought){
            bool payResult = false;
            int cost = SkinsInfo.GetCost(bodyPart)[itemId];
            if (SkinsInfo.isTokens[itemId]) payResult = MoneyManager.SpendTokens(cost);
            else payResult = MoneyManager.SpendMoney(cost);

            if (payResult){
                PlayerPrefs.SetString(bodyPart+"Skins",PlayerPrefs.GetString(bodyPart+"Skins")+":"+itemId);
                PlayerPrefs.Save();
                GetComponentsInParent<RectTransform>()[1].GetComponentInChildren<MoneyPanel>().Start();
                GenerateButton(itemId, bodyPart, true, itemButton);
                itemButton.GenerateButton(itemId, bodyPart, true);
            }
        }
    }


}
