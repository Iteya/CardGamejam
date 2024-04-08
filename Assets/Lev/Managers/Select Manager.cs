using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    public int currentFloor;
    
    public GameObject grid0;
    
    public int maxButtons;
    public static int LevelsVisited = 0;
    public GameObject buttonPrefab;
    public GameObject bossButton;

    [Range(0f, 1f)] public float minWeight;
    [Range(0f, 1f)] public float maxWeight;
    
    private void Awake()
    {
        bossButton.SetActive(false); // Disabling boss button so can't see it until every level cleared 
        
        for (int i = 0; i < LevelsVisited; i++)
        {
            GameObject completedLevelButtons = Instantiate(buttonPrefab, grid0.transform);
            completedLevelButtons.GetComponent<Button>().interactable = false;
        }

        if (LevelsVisited < maxButtons)
        {
 
            for (int i = 0; i < 2; i++)
            {
                GameObject interactableLevelButtons = Instantiate(buttonPrefab, grid0.transform);
                interactableLevelButtons.GetComponent<ButtonSelectorScript>().levelWeight
                    = Random.Range(minWeight, maxWeight);
            }
        }
        else
        {
            bossButton.SetActive(true);
        }
        
    }
}
