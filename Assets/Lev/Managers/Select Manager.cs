using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManager : MonoBehaviour
{
    public LevDeck singleton;
    
    public GameObject grid0;
    
    public int maxButtons;
    [SerializeField] 
    public int LevelsVisited;
    public GameObject buttonPrefab;
    public GameObject bossButton;

    public float minWeight;
    public float maxWeight;
    
    private void Awake()
    {
        bossButton.SetActive(false); // Disabling boss button so can't see it until every level cleared 
        singleton = FindObjectOfType<LevDeck>();
        LevelsVisited = singleton.levels;
        maxWeight = singleton.maxWeight;
        
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
