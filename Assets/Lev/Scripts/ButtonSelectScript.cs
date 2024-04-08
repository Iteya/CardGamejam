    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSelectorScript : MonoBehaviour
{
    public static float SelectedLevelWeight;
    public float levelWeight;

    public void Start()
    {
        gameObject.GetComponent<Image>().color = new Color(1f, 1f - levelWeight, 1f - levelWeight);
    }
    
    public void OpenScene()
    {
        SelectManager.LevelsVisited += 2;
        SelectedLevelWeight = levelWeight;
        SceneManager.LoadScene("Level Scene");
    }
}
