using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardScript : MonoBehaviour
{
    public LevDeck singleton;
    // Start is called before the first frame update
    void Start()
    {
        singleton = FindObjectOfType<LevDeck>();
    }

    public void AddCard()
    {
        singleton.deck.Add(singleton.possibleCardsToAddToDeck[Random.Range(0, singleton.possibleCardsToAddToDeck.Count)]);
        SceneManager.LoadScene("PickingScene");
    }

    public void AddHealth()
    {
        singleton.maxHealth += 10;
        SceneManager.LoadScene("PickingScene");
    }

    public void lowerDifficulty()
    {
        singleton.maxWeight -= Random.Range(.05f, .1f);
    }
}
