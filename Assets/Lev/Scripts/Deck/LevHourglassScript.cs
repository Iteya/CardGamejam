using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevHourglassScript : MonoBehaviour
{
    public LevDeck data;
    public int energy, max;
    public TextMeshProUGUI totalText, currentText;

    private void Update()
    {
        totalText.text = max.ToString();
        currentText.text = energy.ToString();
        /*
        if (enemies == 0)
        {
            enemies = data.enemies;
            data.chooseActions = enemies;
        }
        */
    }
    
    public void SwitchTurn()
    {
        // Checks to see if currentTurn is players turn, if it is, swaps it to Enemy turn
        // If it is not players turn, makes it players turn
        data.currentTurn = LevDeck.TurnAction.Enemy;
    }
    
    /*
    public void EndPlayerTurn()
    {
        if (data.currentTurn == LevDeck.TurnAction.Player)
        {
            Debug.Log("Enemy turn!");
            SwitchTurn();
            data.enemies = enemies;
            data.startIEnumerator = enemies;
        }
    }

    public void EndEnemyTurn()
    {
        if (data.currentTurn == LevDeck.TurnAction.Enemy)
        {
            SwitchTurn();
            data.chooseActions = enemies;
        }
    }
    */
    
    //I split the EndTurn function (now SwitchTurn) so that we can call it for each specific use case
    //I.e. the hourglass itself will EndPlayerTurn, and EndEnemyTurn will be called by whatever handles enemy turn.
}
