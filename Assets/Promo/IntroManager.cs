using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public AudioClip sound;
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        Invoke("StartSecondLogo", 5f);
    }

    void StartSecondLogo(){
        Invoke("MakeSound", 0.8f); 
        Invoke("StartGame", 8f);
    }

    void MakeSound(){
        audio.clip = sound;
        audio.Play();
    }

    void StartGame(){
        Application.LoadLevel("Scenes/MainScene");
    }

    void Update(){
        if (Input.GetMouseButton(0)) StartGame();
    }
}
