using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class LevDrawPile : MonoBehaviour
{
    public LevDeck data;

    public void DrawCard()
    {
        Debug.Log("First step of draw card!");
        if (data.hand.Count < data.maxHandSize)
        {
            Debug.Log("Draw Card being called");
            GameObject instantiatedCard = Instantiate(data.cardPrefab, data.handParent);
            LevCard cardScript = instantiatedCard.GetComponent<LevCard>();

            CardBase drawnCardData = data.deck[0];
            data.deck.RemoveAt(0);
            
            cardScript.data = drawnCardData; // gives data to card
            // #TODO FIX THIS WHEN CARDS ARE REMOVED FROM HAND (it will break lol)
            cardScript.cardHandIndex = data.deckSize; // decides hand index of where it array
            data.hand.Add(drawnCardData);
        }
    }         
} 
  