using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "enemy_data", menuName = "Enemy/enemy_data", order = 1)]
public class EnemyData : ScriptableObject
{
    public int health;
    [Range(0f, 1f)] public float spawnWeight; // between 0 and 1 
    //choices to pick at random
    public List<CardBase> ActionChoices; // All action choices; add damage, defense, and healing as we see fit
    public Color color;
    public HealthBarScript healthBar;
}
