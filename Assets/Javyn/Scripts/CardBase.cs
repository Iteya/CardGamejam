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

    public void ChangeColorBasedOnType(Image image)
    {
        
        if (type == CardType.Poison)
        {
            image.color = new Color(0.561f, 0.737f, 0.561f);
        }
        else if (type == CardType.Fire)
        {
            image.color = new Color(1, 0.278f, 0.278f);
        }
        else if (type == CardType.Normal)
        {
            image.color = new Color(0.737f, 0.682f, 0.682f);
        }
    }
}
