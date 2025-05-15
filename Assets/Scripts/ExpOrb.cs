using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpOrb : MonoBehaviour
{
    public int expValue = 1; //经验值
    public float speed = 5f; //经验球移动速度
    private Transform player; //玩家的Transform组件
    void Start()
    {
        player= GameObject.FindGameObjectWithTag("Player").transform; //找到玩家对象
    }

    // Update is called once per frame
    void Update()
    {
        if(player==null) return; //如果玩家不存在，直接返回
        //计算朝向玩家的方向
        float dist = Vector2.Distance(transform.position, player.position);
        if (dist < 3f) //如果距离小于3f
        {
            transform.position =Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime); //朝向玩家移动
        }
    }
}
