using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankPanel : MonoBehaviour
{
    private Text money;
    private Text tokens;

    private Text[] historySum;
    private Text[] historyTime;

    void Start()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        money = texts[0];
        tokens = texts[1];
        historySum = new Text[]{texts[2], texts[4], texts[6], texts[8], texts[10]};
        historyTime = new Text[]{texts[3], texts[5], texts[7], texts[9], texts[11]};

        UpdatePanel();
    }

    public void UpdatePanel(){
        money.text = ""+PlayerPrefs.GetInt("Money")+"C";
        tokens.text = ""+PlayerPrefs.GetInt("Tokens")+"T";

        string[] operations = PlayerPrefs.GetString("MoneyHistory").Split(';');
        for (int i = 0; i < 5; i++){
            if (operations[i] == "n"){
                historySum[i].text = "";
                historyTime[i].text = ""; 
            } else {
                string[] operation = operations[i].Split(':');

                string sum = operation[0];
                historySum[i].text = ""+sum+"C";
                if (sum[0] == '+') historySum[i].color = new Color(0.77f, 0.88f, 0.65f, 1);
                if (sum[0] == '-') historySum[i].color = new Color(0.94f, 0.60f, 0.60f, 1);

                string time = operation[1];
                historyTime[i].text = ""+time[0]+time[1]+":"+time[2]+time[3]; 
            }
        }
    }

    
}
