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
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        target=GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (target == null) return;
        Vector2 direction = (target.position - transform.position).normalized;
        rb.MovePosition(rb.position+direction*moveSpeed*Time.fixedDeltaTime);
    }
}
