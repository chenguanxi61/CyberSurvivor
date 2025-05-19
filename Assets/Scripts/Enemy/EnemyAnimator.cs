using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    public  Animator animator;
    private EnemyAI enemyAI;
    void Start()
    {
        animator = GetComponent<Animator>();
        enemyAI = GetComponent<EnemyAI>();
    }

    public void Move(bool walk)
    {
        // Set the "isMoving" parameter in the animator to control the walking animation
        animator.SetBool("Run", walk);
    }
}
