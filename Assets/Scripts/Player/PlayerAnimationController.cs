using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerAnimationController : MonoBehaviour
{
 
    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void Move(bool walk)
    {
        // Set the "isMoving" parameter in the animator to control the walking animation
        animator.SetBool("isMoving", walk);
    }
    
    public void Attack()
    {
        animator.SetTrigger("Attack");
    }
    
    public void GetHit()
    {
        animator.SetTrigger("GetHit");
    }
    
    public void Die()
    {
        animator.SetTrigger("Death");
    }
   public void Idle()
    {
        animator.SetBool("isMoving", false);
    }
    
    public void Jump()
    {
        animator.SetTrigger("Jump");
    }
    
    public void Fall()
    {
        animator.SetTrigger("Fall");
    }
    
  
    
}
