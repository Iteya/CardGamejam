using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Deck : MonoBehaviour
{
    public static Deck singleton;

    public Card selected;
    public EnemyScript enemy;

    public List<CardBase> deck, discard;
    public List<CardBase> drawPile;
    public List<Card> cards;
    
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
        //Add starting cards
        for (int i = 0; i < 10; i++)
        {
            deck.Add(drawPile[Random.Range(0, drawPile.Count)]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (deck.Count == 0)
        {
            Draw();
            Shuffle(deck);
        }
        
        //Discard
        if (Input.GetKeyDown(KeyCode.W))
        {
            Discard();
        }
        
        //Shuffle the deck:
        if (Input.GetKeyDown(KeyCode.S))
        {
            Shuffle(deck);
        }
        
        //Draw a card:
        if (Input.GetKeyDown(KeyCode.D))
        {
            DrawCard();
        }
        
        //Delete/discard Debug:
        if (Input.GetKeyDown(KeyCode.W))
        {
            DamageEnemy();
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

    private void DrawCard()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].data == null)
            {
                cards[i].data = deck[0];
                deck.RemoveAt(0);
                return;
            }
        }
    }

    private void Discard()
    {
        discard.Add(selected.data);
        selected.data = null;
        selected = null;
    }

    private void DamageEnemy()
    {
        if (enemy != null && selected != null)
        {
            enemy.health -= selected.damage;
            Debug.Log("damaged!");
            Discard();
        }
    }

    private void Draw()
    {
        deck.AddRange(discard);
    }
}
