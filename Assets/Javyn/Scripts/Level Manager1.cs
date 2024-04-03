using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class J_LevelManager : MonoBehaviour
{
    public LevDeck singleton;
    public LevHourglassScript hourglass;
    
    public Transform[] spawnPositions;
    
    public int enemySpawnLimit;
    public float maxEnemyWeight;
    public GameObject[] enemyOptions;
    
    public int numEnemiesSpawned = 0;
    public float currentEnemyWeight;
    public List<GameObject> enemiesSpawned;
    [HideInInspector] public List<EnemyScript> spawnedEnemiesScripts;

    private void Start()
    {
        singleton = FindObjectOfType<LevDeck>();
        hourglass = FindObjectOfType<LevHourglassScript>();

        maxEnemyWeight = ButtonSelectorScript.SelectedLevelWeight;
        
        while (numEnemiesSpawned < enemySpawnLimit && currentEnemyWeight < maxEnemyWeight)
        {
            int enemySpawned = Random.Range(0, enemyOptions.Length);
            GameObject enemy = Instantiate(enemyOptions[enemySpawned], spawnPositions[numEnemiesSpawned]);
            enemiesSpawned.Add(enemy);
            EnemyScript script = enemy.GetComponent<EnemyScript>();
            spawnedEnemiesScripts.Add(script);
            currentEnemyWeight += script.weight; // adding weight to current enemy weight as to not go over     
            numEnemiesSpawned++;
        }
        
        
    }

    private void Update()
    {
        if (numEnemiesSpawned == 0)
        {
            // EndScene();
        }
    }

    #region EnemyFunctions
        
    public LevDeck.TurnAction EnemyAttackFunctions()
    {
        ChooseEnemyActions();
        TheEnemyDoesActions();
        hourglass.energy = hourglass.max;
        return LevDeck.TurnAction.Player;
    }

    private void ChooseEnemyActions()
    {
        for (int i = 0, len = spawnedEnemiesScripts.Count; i < len; i++)
        {
            spawnedEnemiesScripts[i].ChooseActions(5); // 5 is a random number; placeholder
        }
    }

    private void TheEnemyDoesActions()
    {
        for (int i = 0, len = spawnedEnemiesScripts.Count; i < len; i++)
        {
            EnemyAttackAnimation(enemiesSpawned[i]);
            spawnedEnemiesScripts[i].Actions();
        }
    }

    private void EnemyAttackAnimation(GameObject enemy)
    {
        // GIVE AN ATTACK ANIMATION
        // we could also put this function in EnemyScript.cs if that seems more fitting
    }
    
    #endregion
    
    /*
    private void EndScene()
    {
        Debug.Log("Needs doing.");
        numEnemiesSpawned--;
    }
    */
}
