using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;       // 敌人预制体
    public Transform player;             // 玩家
    public float spawnInterval = 2f;     // 生成间隔
    public int maxEnemies = 20;          // 最大敌人数量
    public float spawnRadius = 10f;      // 敌人生成离玩家多远
    public float cameraBuffer = 2f;      // 多出视野范围多少再生成
    public List<GameObject> enemyPrefabs; // 敌人预制体列表
    private List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            enemies.RemoveAll(e => e == null);

            if (enemies.Count < maxEnemies && enemyPrefabs.Count > 0)
            {
                Vector2 spawnPos = GetOffCameraSpawnPosition();
                // 随机选择一个预制体
                GameObject randomPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
                GameObject enemy = Instantiate(randomPrefab, spawnPos, Quaternion.identity);
                enemies.Add(enemy);
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector2 GetOffCameraSpawnPosition()
    {
        Vector2 playerPos = player.position;

        // 随机方向
        Vector2 randomDir = Random.insideUnitCircle.normalized;

        // 初始生成位置
        Vector2 spawnPos = playerPos + randomDir * spawnRadius;

        // 检查是否在摄像机外
        Camera cam = Camera.main;
        Vector3 viewportPos = cam.WorldToViewportPoint(spawnPos);

        // 如果在屏幕范围内，就继续随机直到不在屏幕范围
        while (viewportPos.x > 0 - cameraBuffer && viewportPos.x < 1 + cameraBuffer &&
               viewportPos.y > 0 - cameraBuffer && viewportPos.y < 1 + cameraBuffer)
        {
            randomDir = Random.insideUnitCircle.normalized;
            spawnPos = playerPos + randomDir * spawnRadius;
            viewportPos = cam.WorldToViewportPoint(spawnPos);
        }

        return spawnPos;
    }
}