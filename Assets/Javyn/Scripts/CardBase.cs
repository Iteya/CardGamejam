using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void TypePoison(Button button)
    {
        //button.colors = new Color(0.561f, 0.737f, 0.561f);
    }

    public void TypeFire(Button button)
    {
        
    }

    public void TypeNormal(Button button)
    {
        
    }
}
