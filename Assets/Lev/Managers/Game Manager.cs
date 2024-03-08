using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevGameManager : MonoBehaviour
{
    public int currentFloor;
    public GameObject grid;

    private List<Transform> buttons = new List<Transform>();
    private void Start()
    {
        foreach (Transform child in grid.transform)
        {
            buttons.Add(child);
        }
        
    }
}
