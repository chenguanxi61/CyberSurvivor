using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private PlayerAnimationController playerAnimationController;
    
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        playerAnimationController = GetComponent<PlayerAnimationController>();  
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput = moveInput.normalized;
        
        if (moveInput.x != 0)
        {
            spriteRenderer.flipX = moveInput.x < 0;
        }
        if (moveInput != Vector2.zero)
        {
            playerAnimationController.Move(true);
        }
        else
        {
            playerAnimationController.Idle();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position+moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}
