using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    void Start()
    {
        currentHealth= maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            GetComponent<EnemyDrop>()?.DropExp();
            Destroy(gameObject);//TODO:播放死亡动画 生成经验球
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
          int damage = other.GetComponent<Bullet>().damage;
          TakeDamage(damage);
        }
    }
}
