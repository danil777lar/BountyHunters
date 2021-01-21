using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRayCast : MonoBehaviour
{
    private Camera cam;

    void Start(){
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            bool isPanelsOff = true;
            IPanel[] panels = GetComponentsInChildren<IPanel>();
            for (int i = 0; i < panels.Length; i++){
                if (panels[i].IsActive()) isPanelsOff = false;
            }

            if (isPanelsOff){
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit)){
                    UIGameObject uigameobject = hit.transform.gameObject.GetComponent<UIGameObject>();
                    if (uigameobject != null){
                        uigameobject.OpenPanel();
                    }
                } 
            }
        }
    }   
}
