using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public Deck data;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.mousePosition.x > transform.position.x - 50 && Input.mousePosition.x < transform.position.x + 50) && (Input.mousePosition.y > transform.position.y - 75 && Input.mousePosition.y < transform.position.y + 75))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //DrawCard(data.cards);
            }
        }
    }

    void DrawCard(List<CardBase> cards)
    {
        //TODO draw card:
        //check if drawn cards < max cards; later
        
        //instantiate a card at xy'
        //give it the carddata that is in the deck;
        //remove card from deck
    }
}
