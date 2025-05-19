using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public Transform target;
    private Rigidbody2D rb;
    private EnemyAnimator enemyAnimator;
    
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        target=GameObject.FindGameObjectWithTag("Player").transform;
        enemyAnimator = GetComponent<EnemyAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyAnimator.Move(true);
    }

    private void FixedUpdate()
    {
        if (target == null) return;

        Vector2 direction = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);

        // 翻转敌人朝向
        if (direction.x > 0)
            transform.localScale = new Vector3(1, 1, 1);   // 面向右
        else if (direction.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);  // 面向左
    }
}
