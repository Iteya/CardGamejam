using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevDeck : MonoBehaviour
{
    public static LevDeck singleton;
    
    public enum turnAction
    {
        Player,
        Enemy,
    }
    public turnAction currentTurn;

    public List<CardBase> possibleCardsToAddToDeck;
    public List<CardBase> deck;
    public int deckSize;
    public List<CardBase> discard;
    public List<CardBase> hand;

    public Transform handParent;

    private void Awake()
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

    private void Start()
    {
        for (int i = 0; i < deckSize; i++)
        {
            deck.Add(possibleCardsToAddToDeck[Random.Range(0, possibleCardsToAddToDeck.Count)]);
        }
    }
}
