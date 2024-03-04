using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "enemy_data", menuName = "Enemy/enemy_data", order = 1)]
public class EnemyData : ScriptableObject
{
    public int health;
    [Range(0f, 1f)] public float spawnWeight; // between 0 and 1 
    //choices to pick at random
    public int[] damageChoices; // deciding on damage
    public int[] defenseChoices; // deciding defence
    public int[] healingChoices; // deciding health (most enemies probably wont use this)


}
