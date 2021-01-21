using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CupboardPanel : MonoBehaviour, IPanel
{
    public SkinManager scenePerson;
    public SkinManager panelPerson;

    public Image exitButton;

    private string title;
    private Color color = new Color(0,0,0);

    public bool IsActive(){
        return gameObject.active;
    }
    
    public void ClosePanel(){
        GetComponent<Animator>().Play("StateLayer.Close");
        Invoke("CloseEnd", .40f);
    }

    private void CloseEnd(){
        GetComponentInChildren<ContentGenerator>().Start();
        ChangeColor("Head");
        scenePerson.Start();
        panelPerson.Start();
        gameObject.SetActive(false);
    }

    public void ChangeColor(string bodyPart){
        title = bodyPart; 
        int buttonId = 0;
        switch (bodyPart){
            case "Head":
                color = new Color(.56f, .79f, .98f);
                buttonId = 0;
            break;
            case "Body":
                color = new Color(.50f, .80f, .77f);
                buttonId = 1;
            break;
            case "Leg":
                color = new Color(.90f, .93f, .61f);
                buttonId = 2;
            break;
        }
        BodyPartButton[] buttons = GetComponentsInChildren<BodyPartButton>();
        for (int i = 0; i < 3; i++){
            if (i == buttonId){
                buttons[i].GetComponentInChildren<Image>().color = color;
            } else {
                buttons[i].GetComponentInChildren<Image>().color = new Color(.42f, .42f, .42f);
            }
        }
        GetComponentsInChildren<Image>()[1].color = color;
        Invoke("ChangeTitle", 0.3f);
        GetComponent<Animator>().Play("Base Layer.ChangePart");
    }

    private void ChangeTitle(){
        Text text = GetComponentsInChildren<Text>()[0]; 
        text.text = Assets.SimpleLocalization.LocalizationManager.Localize("Cupboard."+title);
        exitButton.color = color;
        text.color = color;

    }
}
