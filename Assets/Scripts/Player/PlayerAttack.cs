using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float attackInterval = 1f;
    private PlayerAnimationController playerAnimationController;
    private float attackTimer;
    void Start()
    {
        playerAnimationController = GetComponent<PlayerAnimationController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackInterval)
        {
            if (Input.GetMouseButton(0))
            {
                playerAnimationController.Attack();
            }
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
