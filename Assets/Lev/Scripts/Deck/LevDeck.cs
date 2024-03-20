using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevDeck : MonoBehaviour
{
    public static LevDeck singleton;

    public GameObject cardPrefab;
    
    public enum TurnAction
    {
        Player,
        Enemy,
    }
    public TurnAction currentTurn;

    public List<CardBase> possibleCardsToAddToDeck;
    public List<CardBase> deck;
    public int deckSize;
    public List<CardBase> discard;
    public List<CardBase> hand;
    public int maxHandSize;
    // keep track of current selected card via index
    public int currentSelectedCard = -1; // if -1, stands for no card selected

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
        // Adding starting cards to deck
        for (int i = 0; i < deckSize; i++)
        {
            deck.Add(possibleCardsToAddToDeck[Random.Range(0, possibleCardsToAddToDeck.Count)]);
        }

        currentTurn = TurnAction.Player;
    }

    private void Update()
    {
        #region PlayerFunctionCalls

        if (currentTurn == TurnAction.Player)
        {
            Damage();
        }
            

        #endregion
    }

    #region PlayerFunctions

        private void Damage()
        {
            if (currentSelectedCard != -1)
            {
                
            }
        }
    

    #endregion
    
    
}
