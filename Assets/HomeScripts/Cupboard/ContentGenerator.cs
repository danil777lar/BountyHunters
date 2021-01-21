using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentGenerator : MonoBehaviour
{
    public static string HEAD = "Head";
    public static string BODY = "Body";
    public static string LEG = "Leg";

    public string currentBodyPart;

    public ItemButton clickedItem;
    public ItemButton selectedItem;

    private int screenCapacity = 5;
    private float lastPosition = 0;
    private float size;

    private RectTransform rectTransform;

    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.offsetMax = new Vector2(0, 0);
        rectTransform.offsetMin = new Vector2(0, 0);
        MakeContent(HEAD);
    }

    public void MakeContent(string bodyPart){
        CleanSpace();

        currentBodyPart = bodyPart;

        int elementQuantity = SkinsInfo.GetCost(bodyPart).Length;
        rectTransform.anchorMin = new Vector2(0, 1f-(elementQuantity*(1f/screenCapacity)));
        rectTransform.offsetMin = new Vector2(0, 0);
        size = -1*(rectTransform.anchorMin.y-rectTransform.anchorMax.y);

        string[] boughtItems = PlayerPrefs.GetString(bodyPart+"Skins").Split(':');
        string[] saleItems = new string[elementQuantity-boughtItems.Length];
        // //////////////////////////////////////////////////
        int s = 0;
        for (int i = 0; i < elementQuantity; i++){
            bool isEqual = false;
            for (int k = 0; k < boughtItems.Length; k++){
                if (""+i == boughtItems[k]) isEqual = true;
            }
            if (!isEqual){
                saleItems[s] = ""+i;
                s++;
            }
        }
        // ////////////////////////////////////////////////
        for (int i = 0; i < elementQuantity; i++){
            GameObject temple = Instantiate(Resources.Load<GameObject>("Prefabs/UI/ClothButton"));
            RectTransform templeTransform = temple.GetComponent<RectTransform>();
            templeTransform.SetParent(rectTransform);
            templeTransform.localScale = new Vector3(1, 1, 1);
            templeTransform.anchorMax = new Vector2(1, rectTransform.anchorMax.y-lastPosition);
            templeTransform.anchorMin = new Vector2(0, (rectTransform.anchorMax.y-lastPosition)-1f/(screenCapacity*size));
            templeTransform.offsetMax = new Vector2(0, 0);
            templeTransform.offsetMin = new Vector2(0, 0);
            lastPosition += 1f/(screenCapacity*size);

            if (i > boughtItems.Length-1){
                int k = i - boughtItems.Length;
                temple.GetComponent<ItemButton>().GenerateButton(int.Parse(saleItems[k]), bodyPart, false);
            } else temple.GetComponent<ItemButton>().GenerateButton(int.Parse(boughtItems[i]), bodyPart, true);
        }
    }

    private void CleanSpace(){
        RectTransform[] items = GetComponentsInChildren<RectTransform>();
        for (int i = 1; i < items.Length; i++){
            Destroy(items[i].gameObject);
        }
        lastPosition = 0;
    }
}
