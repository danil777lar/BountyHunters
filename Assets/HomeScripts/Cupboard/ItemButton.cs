using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemButton : MonoBehaviour
{
    public Text point;

    private ContentGenerator cg;

    private int itemId;
    private string bodyPart;
    private bool isBought;
    private Color color = new Color(0,0,0);

    public void GenerateButton(int itemId, string bodyPart, bool isBought){
        this.itemId = itemId;
        this.bodyPart = bodyPart;
        this.isBought = isBought;

        Text text = GetComponentInChildren<Text>();
        text.text = SkinsInfo.GetName(bodyPart, itemId).ToUpper();
        if (!isBought) text.color = new Color(0.487797f, 0.526599f, 0.546f);

        cg = GetComponentInParent<ContentGenerator>();
        int bodyPartId = 0; 
        switch (bodyPart){
            case "Head":
                color = new Color(.56f, .79f, .98f);
                bodyPartId = 0;
            break;
            case "Body":
                color = new Color(.50f, .80f, .77f);
                bodyPartId = 1;
            break;
            case "Leg":
                color = new Color(.90f, .93f, .61f);
                bodyPartId = 2;
            break;
        }
        if (int.Parse(PlayerPrefs.GetString("SelectedSkins").Split(':')[bodyPartId]) == itemId){
            cg.clickedItem = this;
            cg.selectedItem = this;
            ButtonClicked();
            MakeSelected();
        }
    }

    public void ButtonClicked(){
        SkinManager skinManager = GetComponentInParent<SkinsPanel>().person;
        GetComponentInParent<SkinsPanel>().acceptButton.GenerateButton(itemId, bodyPart, isBought, this);
        MakeClicked();
        switch (bodyPart){
            case "Head":
                skinManager.MakeHead(itemId);
            break;
            case "Body":
                skinManager.MakeBody(itemId);
            break;
            case "Leg":
                skinManager.MakeLegs(itemId);
            break;
        }
    }

    public void MakeSelected(){
        cg.selectedItem.point.gameObject.SetActive(false);
        point.gameObject.SetActive(true);
        point.color = color;
        cg.selectedItem = this;
    }

    private void MakeClicked(){
        cg.clickedItem.GetComponentInChildren<Text>().color = new Color(.91f, .91f, .91f);
        GetComponentInChildren<Text>().color = color;
        cg.clickedItem = this;
    }
}
