using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        Debug.Log("玩家受伤。当前血量：" + currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("玩家死亡。");
            Destroy(gameObject); //TODO:播放死亡动画
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            //int damage = other.GetComponent<EnemyAI>().damage;  假设敌人有一个damage属性
            TakeDamage(1);
        }
    }
}
