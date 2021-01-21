using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameObject : MonoBehaviour
{
    public GameObject panel;

    public void OpenPanel(){
        GetComponent<AudioSource>().Play();
        panel.SetActive(true);
        panel.GetComponent<Animator>().Play("StateLayer.Open");
    }
}
