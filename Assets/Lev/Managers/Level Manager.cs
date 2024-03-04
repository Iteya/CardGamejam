using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public int enemySpawnLimit;
    public float maxEnemyWeight;
    public GameObject[] enemyOptions;
    
    public int numEnemiesSpawned;
    public float currentEnemyWeight;
    public GameObject[] spawnedEnemies;

    private void Start()
    {
        while (numEnemiesSpawned < enemySpawnLimit && currentEnemyWeight < maxEnemyWeight)
        {
            GameObject enemy = enemyOptions[Random.Range(0, enemyOptions.Length)];
            numEnemiesSpawned++;
            MonoBehaviour enemyScript = enemy.GetComponent<MonoBehaviour>();
        }
    }
}
