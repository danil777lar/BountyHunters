using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public float speed;
    public LevelModuleMoving level;
    public bool isEnemy;
    private Animator animator;
    private bool lastEndingState = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isEnemy", isEnemy);    
    }

    void Update()
    {
        if (level != null){
            if (!level.isMotionStoped) speed = level.speed/10f;
            else speed = 1f;
            animator.speed = speed;
            animator.SetBool("isEndingStart", level.isMotionStoped);
        }
    }
}
