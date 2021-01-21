using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public bool isEnemy;

    private SpriteRenderer headSprite;
    private SpriteRenderer[] bodySprites;
    private SpriteRenderer[] legSprites;    

    public void Start()
    {
        SpriteRenderer[] allSprites = GetComponentsInChildren<SpriteRenderer>();
        headSprite = allSprites[11];
        bodySprites = new SpriteRenderer[]{allSprites[0], allSprites[2], allSprites[3], allSprites[4], allSprites[5]};
        legSprites = new SpriteRenderer[]{allSprites[1], allSprites[6], allSprites[7], allSprites[8], allSprites[9]};

        if (!isEnemy){
            string[] selectedSkins = PlayerPrefs.GetString("SelectedSkins").Split(':'); 
            MakeHead(int.Parse(selectedSkins[0]));
            MakeBody(int.Parse(selectedSkins[1]));
            MakeLegs(int.Parse(selectedSkins[2]));
        } else {
            MakeHead(EnemySkinConstructor.headId);
            MakeBody(EnemySkinConstructor.bodyId);
            MakeLegs(EnemySkinConstructor.legId);
        }
    }

    public void MakeHead(int itemId){
        headSprite.sprite = Resources.Load<Sprite>("Sprites/Hairs/"+itemId+"/0");
    }

    public void MakeBody(int itemId){
        for(int i = 0; i < bodySprites.Length; i++){
            bodySprites[i].sprite = Resources.Load<Sprite>("Sprites/Arms/"+itemId+"/"+i);
        }
    }

    public void MakeLegs(int itemId){
        for(int i = 0; i < legSprites.Length    ; i++){
            legSprites[i].sprite = Resources.Load<Sprite>("Sprites/Legs/"+itemId+"/"+i);
        }
    }
}
