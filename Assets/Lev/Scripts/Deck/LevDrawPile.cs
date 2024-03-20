using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevDrawPile : MonoBehaviour
{
    public LevDeck data;
    public int indexInHand;
    
    public void DrawCard()
    {
        if (data.deckSize <= data.maxHandSize)
        {
            GameObject instantiatedCard = Instantiate(data.cardPrefab, data.handParent);
            
        }
    }
}
