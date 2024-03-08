using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorScript : MonoBehaviour
{
    public static float SelectedLevelWeight;
    public float levelWeight;
    
    public void OpenScene()
    {
        SelectedLevelWeight = levelWeight;
        SceneManager.LoadScene("Level Scene");
    }
}
