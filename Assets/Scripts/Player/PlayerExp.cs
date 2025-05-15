using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    public int currentExp = 0; //当前经验值
    public int level = 1; //当前等级
    public int expToNextLevel = 5; //升级所需经验值
    
    public void AddExp(int amount)
    {
        currentExp += amount; //增加经验值
        Debug.Log("当前经验值：" + currentExp);
        if (currentExp >= expToNextLevel) //如果经验值达到升级所需经验值
        {
            LevelUp(); //升级
        }
    }

    void LevelUp()
    {
        level++; //升级
        currentExp -= expToNextLevel; //扣除升级所需经验值
        expToNextLevel += 5; //增加下一级所需经验值
        Debug.Log("升级！当前等级：" + level);
        //TODO:打开升级界面   
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ExpOrb")) //如果碰到经验球
        {
            int exp = other.GetComponent<ExpOrb>().expValue; //获取经验球的经验值
            AddExp(exp); //增加经验值
            Destroy(other.gameObject); //销毁经验球
        }
    }
}
