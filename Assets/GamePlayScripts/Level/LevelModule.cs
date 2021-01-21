using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModule : MonoBehaviour
{
    public Transform LeftSide;
    public Transform RightSide;

    private int barriersNum = 4;

    private int moduleId;
    private int generateChance;
    private int minSpace;

    public void Generate(int moduleId, int generateChance, int minSpace, bool isFirst){
        this.moduleId = moduleId;
        this.generateChance = generateChance;
        
        int l = 0;
        if (isFirst) l = 50;
        while (l < 90){
            int rand = Random.Range(0, 100);
            if(rand < generateChance){
                int barrierId = Random.Range(0, barriersNum);
                GameObject barrier = Instantiate(Resources.Load<GameObject>("Prefabs/Map/"+moduleId+"/barriers/"+barrierId));
                int lenght = barrier.GetComponent<Barrier>().lenght;
                if(lenght > 100 - l) Destroy(barrier);
                else {
                    barrier.transform.parent = transform;
                    barrier.transform.localPosition = new Vector2(l-50f, 2.5f);
                    l += lenght + minSpace;
                }
            } else {
               l += 5; 
            }
        }
    }

    public void Generate(){}
}
