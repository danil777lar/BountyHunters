using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPanel : MonoBehaviour, IPanel
{
    private Text text;
    private Text pressText;
    private TutorialSFX sound;
    private Animator anim;

    private bool animPlayed = false;
    private bool isTyping = false;
    private int dialogNum = 0;
    private int dialogPart = 0;
    private int[] dialogParts = {1, 1, 2, 2};
    private float[] animDuration = {1f, .1f, .52f, 2f};

    private int charI;
    private string typingString;

    void Start()
    {
        anim = GetComponent<Animator>();
        sound = GetComponent<TutorialSFX>();
        text = GetComponentInChildren<Text>();
        pressText = GetComponentsInChildren<Text>()[1];
        Typing();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isTyping){
            text.text = "";
            Typing();
        }
    }

    void Typing(){
        if (!animPlayed){
            if (dialogNum < dialogParts.Length){
                anim.Play("Base Layer."+dialogNum);
                animPlayed = true;
                Invoke("Typing", animDuration[dialogNum]);
            } else {
                anim.Play("Base Layer.4");
                Invoke("Close", 1f);
            }
            pressText.gameObject.SetActive(false);
        }
        else if (!isTyping){
            isTyping = true;
            pressText.gameObject.SetActive(false);
            charI = 0;
            typingString = Assets.SimpleLocalization.LocalizationManager.Localize("Tutorial."+dialogNum+dialogPart);
            Invoke("Typing", .01f);
        } else {
            if (charI < typingString.Length){
                text.text += typingString[charI];
                sound.TypeSound();
                charI++;
                Invoke("Typing", .01f);
            } else {
                isTyping = false;
                pressText.gameObject.SetActive(true);
                if (dialogPart+1 < dialogParts[dialogNum]) dialogPart++;
                else {
                    dialogPart = 0;
                    dialogNum++;
                    animPlayed = false;
                }
            }
        }
    }

    void Close(){
        Destroy(gameObject);
    }

    public bool IsActive(){
        return gameObject.active;
    }
}
