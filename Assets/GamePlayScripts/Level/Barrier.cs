using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public int lenght;

    public GameObject touch;

    void Start()
    {
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            GetComponent<Animator>().Play("Base Layer.TouchAnim");
            GetComponentInParent<LevelModuleMoving>().GameOver(false); 
            Destroy(gameObject, 1f);
        }
    }
}
