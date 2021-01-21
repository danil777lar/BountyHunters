using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrackGenerator : MonoBehaviour
{
    public float partDuration;
    private AudioClip[] clips;
    private AudioSource front;
    private AudioSource back;

    void Start()
    {
        clips = Resources.LoadAll<AudioClip>("Soundtrack");
        AudioSource[] sources = GetComponentsInChildren<AudioSource>();
        front = sources[0];
        front.clip = clips[Random.Range(0, clips.Length)];
        front.Play();
        back = sources[1];
        ChangePart();
    }

    void ChangePart(){
        if (Random.Range(0, 2) == 1){
            back.clip = clips[Random.Range(0, clips.Length)];
            back.Play();
        }
        Invoke("ChangePart", partDuration);
    }
}
