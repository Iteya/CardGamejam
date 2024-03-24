using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevCard : MonoBehaviour
{
    public CardBase data;
    public Image image;
    public TextMeshProUGUI tCardName, tManaCost, tDamage, tDescription;
    public LevDeck singleton;
    public int damage, manaCost, cardHandIndex;

    private void Start()
    {
        singleton = FindObjectOfType<LevDeck>();
        
        damage = data.damage;
        manaCost = data.manaCost;

        tCardName.text = data.cardName;
        tManaCost.text = data.manaCost.ToString();
        tDamage.text = data.damage.ToString();
        tDescription.text = data.description;

        data.ChangeColorBasedOnType(image);
    }

    public void CardSelected()
    {
        singleton.selectedCard = cardHandIndex;
        
    }

    private void OnDestroy()
    {
        singleton.hand.RemoveAt(cardHandIndex);
        singleton.discard.Add(data);
        for (int i = cardHandIndex, len = singleton.hand.Count; i < len; i++)
        {
            singleton.hand[i].cardHandIndex -= 1;
        }
        singleton.selectedCard = -1;
    }
}

