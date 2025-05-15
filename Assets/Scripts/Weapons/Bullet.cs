using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;
    public int damage = 1;
    
    private Vector2 direction;
    
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject,lifetime);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(("Enemy")))
        {
            //TODO:扣血
            Destroy(gameObject);
        }
       
    }
}
