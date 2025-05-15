using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtteck : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float attackInterval = 1f;
    
    private float attackTimer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackInterval)
        {
            Fire();
            attackTimer = 0f;
        }
    }
    
    
    
    void Fire()
    {
        Vector2 fireDir=GetMouseDirection();
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDirection(fireDir);
    }
    
    
    Vector2 GetMouseDirection()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = (mouseWorldPos - transform.position);
        return dir.normalized;
    }
}
