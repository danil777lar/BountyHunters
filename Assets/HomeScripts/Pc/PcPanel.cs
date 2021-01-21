using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PcPanel : MonoBehaviour, IPanel
{
    public GameObject mainMenu;
    public GameObject playMenu;
    public GameObject statMenu;

    private Animator animator;

    public bool IsActive(){
        return gameObject.active;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void TurnOffPc(){
        animator.Play("StateLayer.Close");
        Invoke("TurnOffEnd", .4f);
    }
    private void TurnOffEnd(){
        playMenu.SetActive(false);
        statMenu.SetActive(false);
        gameObject.SetActive(false);
    }

    public void TasksButton(){
        playMenu.SetActive(true);
        SuspectButton[] suspects = GetComponentsInChildren<SuspectButton>();
        for (int i = 0; i < suspects.Length; i++) suspects[i].CreatePanel(i);
        animator.Play("ScreenLayer.OpenHuntersPanel");
    }

    public void StatButton(){
        statMenu.SetActive(true);
        StatField[] fields = GetComponentsInChildren<StatField>();
        for (int i = 0; i < fields.Length; i++){
            fields[i].Start();
        }
        animator.Play("ScreenLayer.OpenStatPanel");
    }

    public void BackToMenu(){
        animator.Play("ScreenLayer.Close"+GetComponentsInChildren<RectTransform>()[2].gameObject.name);
    }

    public void PlayFreeMode(){
        LevelConstructor.isFreeMode = true;
        EnemyConstructor.cost = 0;
        Application.LoadLevel("Scenes/SampleScene");
    }


}
