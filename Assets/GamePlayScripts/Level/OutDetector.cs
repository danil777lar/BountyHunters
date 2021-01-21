using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutDetector : MonoBehaviour
{
    private bool messageWasSended = false;
    private AudioSource audio;

    void Start(){
        audio = GetComponent<AudioSource>();
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.tag == "Player" && !messageWasSended){
            GetComponentInParent<ScoreCounter>().AddScorePoint();
            messageWasSended = true;
            audio.Play();
        }
    }
}
