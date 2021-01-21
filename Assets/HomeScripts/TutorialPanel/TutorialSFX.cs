using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSFX : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioClip typeSound;

    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void ClickSound(){
        audio.clip = clickSound;
        audio.Play();
    }

    public void TypeSound(){
        audio.clip = clickSound;
        audio.Play();
    }
}
