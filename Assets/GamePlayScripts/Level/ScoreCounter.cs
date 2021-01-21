using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreWidget;

    private int scorePoints = 0;

    public void AddScorePoint(){
        scorePoints += 1; 
        scoreWidget.text = ""+scorePoints;
    }

    public int GetScore(){
        return scorePoints;
    }
    
}
