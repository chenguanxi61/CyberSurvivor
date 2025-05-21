using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    private EnemyAnimator animator;
    void Start()
    {
        currentHealth= maxHealth;
        animator = GetComponent<EnemyAnimator>();
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
            animator.Die();
            GetComponent<EnemyDrop>()?.DropExp();
            StartCoroutine(destroyAfterAnimation()); // 使用协程延迟销毁
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
          int damage = other.GetComponent<Bullet>().damage;
          animator.Hit();
          TakeDamage(damage);
        }
    }
    
    private IEnumerator destroyAfterAnimation()
    {
        // 假设死亡动画长度为 1 秒，根据实际情况调整
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
