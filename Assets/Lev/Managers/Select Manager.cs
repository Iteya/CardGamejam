using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    public int currentFloor;
    private static bool[] _levelsBeat; // Bool keep track of level index beat
    
    public GameObject grid;
    public List<GameObject> buttons = new List<GameObject>();
    public GameObject bossButton;

    [Range(0f, 1f)] public float minWeight;
    [Range(0f, 1f)] public float maxWeight;
    
    private void Awake()
    {
        for (int i = 0, len = buttons.Count; i < len; i++)
        {
            buttons[i].GetComponent<ButtonSelectorScript>().levelWeight = Random.Range(minWeight, maxWeight);
        }
    }
}
