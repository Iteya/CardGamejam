using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBase : ScriptableObject
{
    public GameObject prefab;
    [TextArea(15, 20)] 
    public string description;
    [TextArea(1, 10)] public string cardName, sManaCost, sDamage;
    public bool isPoison, isFire;
    public int manaCost, damage;
    public GameObject upgrade;
}
