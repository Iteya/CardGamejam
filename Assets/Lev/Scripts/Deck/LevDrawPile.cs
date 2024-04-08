using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class LevDrawPile : MonoBehaviour
{
    public LevDeck data;

    public void Start()
    {
        data = FindObjectOfType<LevDeck>();
    }

    public void DrawCard()
    {
        if (data.hand.Count < data.maxHandSize && data.deck.Count > 0)
        {
            GameObject instantiatedCard = Instantiate(data.cardPrefab, data.levelManager.cardsInHandParent);
            LevCard cardScript = instantiatedCard.GetComponent<LevCard>();

            CardBase drawnCardData = data.deck[0];
            data.deck.RemoveAt(0);
            
            cardScript.data = drawnCardData; // gives data to card
            
            //TODO FIX THIS WHEN CARDS ARE REMOVED FROM HAND (it will break lol)
            cardScript.cardHandIndex = data.hand.Count; // decides hand index of where it array
            data.hand.Add(cardScript);
        }
    }         
} 
  