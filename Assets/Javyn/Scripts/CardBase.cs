using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    Normal,
    Poison,
    Fire
}

[CreateAssetMenu(fileName = "Card", menuName = "Cards/Card", order = 1)]

public class CardBase : ScriptableObject
{
    public GameObject prefab;
    [TextArea(15, 20)] public string description;
    [TextArea(1, 10)] public string cardName;

    public CardType type;
        
    public int manaCost, damage;
    public CardBase upgrade;
}
