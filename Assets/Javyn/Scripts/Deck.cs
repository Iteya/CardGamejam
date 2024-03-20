using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Deck : MonoBehaviour
{
    public static Deck singleton;
    public Hourglass hourglass;
    public Card selected;
    public EnemyScript enemy;

    public enum turnAction {
        Player,
        Enemy,
    }

    public turnAction turn;

    public List<CardBase> deck, discard;
    public List<CardBase> drawPile;
    public List<Card> cards;

    public List<EnemyScript> attackedEnemies;
    public List<CardBase> usedCards;

    public Transform parent;
    
    void Awake() {
        if (singleton != null && singleton != this) {
            Destroy(gameObject);
        }
        else {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start() {
        //Add starting cards
        for (int i = 0; i < 10; i++) {
            deck.Add(drawPile[Random.Range(0, drawPile.Count)]);
        }

        turn = turnAction.Player;

        //Card cardToPlay = Instantiate(cards[0], new Vector3(transform.position.x, transform.position.y, 0), quaternion.identity, parent);
    }

    // Update is called once per frame
    void Update() {
    #region PlayerFunctions
    
        if (turn == turnAction.Player) {
            Damage();
            
            // Draw cards
            
            // End turn
            
            if (deck.Count == 0) {
                Draw();
                Shuffle(deck);
            }
        }

    #endregion

    #region EnemyActions

    if (turn == turnAction.Enemy) {
        
    }

    #endregion
    
    
    #region DebugFunctions

        //Discard
        if (Input.GetKeyDown(KeyCode.W)) {
            Discard();
        }
        
        //Shuffle the deck:
        if (Input.GetKeyDown(KeyCode.S)) {
            Shuffle(deck);
        }
        
        //Draw a card:
        if (Input.GetKeyDown(KeyCode.D)) {
            DrawCard();
        }

    #endregion
    }
    
    private void Shuffle(List<CardBase> list) {
        for (int i = 0; i < list.Count; i++) {
            int a = Random.Range(0, list.Count);
            int b = Random.Range(0, list.Count);
            (list[a], list[b]) = (list[b], list[a]);
        }
    }

    public void DrawCard() {
        for (int i = 0; i < cards.Count; i++) {
            if (cards[i].data == null) {
                cards[i].data = deck[0];
                deck.RemoveAt(0);
                return;
            }
        }
    }

    private void Discard() {
        discard.Add(selected.data);
        selected.data = null;
        selected = null;
    }
    
    private void Damage()
    {
        if (enemy != null && selected != null && hourglass.energy - selected.manaCost >= 0) {
            enemy.health -= selected.damage;
            hourglass.energy -= selected.manaCost;
            //poison
            //fire
            //ect
            Discard();
            enemy = null;
        }
        else if (enemy != null && selected != null && hourglass.energy - selected.manaCost < 0) {
            selected = null;
            enemy = null;
        }
    }

    private void Draw() {
        if (turn == turnAction.Player) {
            deck.AddRange(discard);
            discard.Clear();
        }
    }
    
    public void EndTurn()
    {
        if (turn == turnAction.Player) {
            turn = turnAction.Enemy;
        }
    }
}
