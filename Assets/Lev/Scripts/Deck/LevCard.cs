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
        singleton = GetComponent<LevDeck>();
        
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
        singleton.currentSelectedCard = cardHandIndex;
    }

    private void OnDestroy()
    {
        singleton.currentSelectedCard = -1;
    }
}

