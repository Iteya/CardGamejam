using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevDeck : MonoBehaviour
{
    public enum TurnAction
    {
        Player,
        Enemy,
    }
    
    [Header("Libraries")]
    public static LevDeck singleton;
    public GameObject cardPrefab;
    public Transform handParent;
    public LevHourglassScript hourglass;
    
    [Header("Values")]
    public TurnAction currentTurn;
    public int enemies;
    public int deckSize;
    public int maxHandSize;
    public int chooseActions = 0;
    public int startIEnumerator = 0;
    
    [Header("Lists")]
    public List<CardBase> possibleCardsToAddToDeck, deck;
    public List<CardBase> discard;
    public List<LevCard> hand;
    
    [Header("")]
    public EnemyScript selectedEnemy;
    // keep track of current selected card via index
    public int selectedCard = -1; // if -1, stands for no card selected

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
            if (selectedCard != -1 && selectedEnemy != null)
            {
                if (hourglass.energy - hand[selectedCard].manaCost >= 0) 
                {
                    selectedEnemy.ChangeHealth(-hand[selectedCard].damage);
                    
                    hourglass.energy -= hand[selectedCard].manaCost;
                    
                    Destroy(hand[selectedCard].gameObject);
                }

                selectedCard = -1;
                selectedEnemy = null;
            }
        }
    #endregion
    
}
