using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    public Transform[] spawnPositions;
    
    public int enemySpawnLimit;
    public float maxEnemyWeight;
    public GameObject[] enemyOptions;
    
    public int numEnemiesSpawned = 0;
    public float currentEnemyWeight;
    public List<GameObject> enemiesSpawned = new List<GameObject>();

    private void Start()
    {
        maxEnemyWeight = ButtonSelectorScript.SelectedLevelWeight;
        while (numEnemiesSpawned < enemySpawnLimit && currentEnemyWeight < maxEnemyWeight)
        {
            int enemySpawned = Random.Range(0, enemyOptions.Length);
            GameObject enemy = Instantiate(enemyOptions[enemySpawned], spawnPositions[numEnemiesSpawned]);
            enemiesSpawned.Add(enemy);
            numEnemiesSpawned++;
            EnemyScript script = enemy.GetComponent<EnemyScript>();
            currentEnemyWeight += script.weight;
        }
    }
}
