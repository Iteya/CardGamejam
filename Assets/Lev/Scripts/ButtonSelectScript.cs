    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
    using Random = UnityEngine.Random;

    public class ButtonSelectorScript : MonoBehaviour
{
    public static float SelectedLevelWeight;
    public float levelWeight;
    public LevDeck singleton;

    public void Start()
    {
        gameObject.GetComponent<Image>().color = new Color(1f, 1f - levelWeight, 1f - levelWeight);
        singleton = FindObjectOfType<LevDeck>();
    }
    
    public void OpenScene()
    {
        singleton.maxWeight += Random.Range(.05f, .1f);
        singleton.levels += 2;
        if (singleton.levels == 8)
        {
            singleton.levels = 0;
            singleton.floor++;
        }
        SelectedLevelWeight = levelWeight;
        SceneManager.LoadScene("Level Scene");
    }
}