using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public EnemyData data;

    public float weight;

    private void Awake()
    {
        weight = data.spawnWeight;
    }
}
