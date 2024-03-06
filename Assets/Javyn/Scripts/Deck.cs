using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Deck : MonoBehaviour
{
    public static Deck singleton;

    public Card selectedCard;
    public List<CardBase> cards;
    public List<CardBase> cardToAppend;
    
    void awake()
    {
        if (singleton != null && singleton != this)
        {
            Destroy(gameObject);
        }
        else
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Add a new card to the deck:
        if (Input.GetKeyDown(KeyCode.A))
        {
            cards.Add(cardToAppend[Random.Range(0, cardToAppend.Count)]);
        }
        
        //Shuffle the deck:
        if (Input.GetKeyDown(KeyCode.S))
        {
            Shuffle(cards);
        }
    }
    
    private void Shuffle(List<CardBase> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int a = Random.Range(0, list.Count);
            int b = Random.Range(0, list.Count);
            (list[a], list[b]) = (list[b], list[a]);
        }
    }
}
