using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour
{
   public GameObject expOrbPrefab; //经验球预制体


   public void DropExp()
   {
      Instantiate(expOrbPrefab, transform.position, Quaternion.identity); //在敌人位置生成经验球
   }
}
