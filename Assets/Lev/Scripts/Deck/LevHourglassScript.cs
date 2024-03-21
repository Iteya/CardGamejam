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
    }
    
    public void EndTurn()
    {
        // Checks to see if currentTurn is players turn, if it is, swaps it to Enemy turn
        // If it is not players turn, makes it players turn
        data.currentTurn = data.currentTurn == LevDeck.TurnAction.Player
            ? LevDeck.TurnAction.Enemy
            : LevDeck.TurnAction.Player;
    }
}
