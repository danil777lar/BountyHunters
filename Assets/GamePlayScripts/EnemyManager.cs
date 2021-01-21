using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public LevelModuleMoving level;

    void Start()
    {
        if (LevelConstructor.isFreeMode) Destroy(gameObject);
    }

    void Update()
    {
        if (level.speed >= EnemyConstructor.maxSpeed){
            level.GameOver(true);
        }
    }
}
