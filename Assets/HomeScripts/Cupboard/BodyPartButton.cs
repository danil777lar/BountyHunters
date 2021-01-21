using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartButton : MonoBehaviour
{
    public string bodyPart;
    public ContentGenerator contentGenerator;
    public SkinManager person;

    public void ButtonClicked(){
        GetComponentInParent<CupboardPanel>().ChangeColor(bodyPart);
        Invoke("MakeContent", 0.2f);
    }

    private void MakeContent(){
        contentGenerator.MakeContent(bodyPart);
        person.Start();
    }
}
