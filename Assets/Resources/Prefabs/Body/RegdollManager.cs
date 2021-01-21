using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegdollManager : MonoBehaviour
{
    public void DoDeath(){
        GetComponentInChildren<Animator>().enabled = false;
        Rigidbody2D[] rbs = GetComponentsInChildren<Rigidbody2D>();
        for (int i = 0; i < rbs.Length; i++){
            rbs[i].simulated = true;
            rbs[i].freezeRotation = false;
        }
    }
}
