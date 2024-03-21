using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnRate = 8f;
    public float widthOffset = 10f;

    private float timer = 0f;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnEnemy();
            timer = spawnRate;
        }
    }

    void SpawnEnemy()
    {
        float leftBoundary = transform.position.x - widthOffset;
        float rightBoundary = transform.position.x + widthOffset;

        float randomX = Random.Range(leftBoundary, rightBoundary);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}