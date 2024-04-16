using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeginTheClimbExe : MonoBehaviour
{
    public void BeginTheClimb()
    {
        SceneManager.LoadScene("PickingScene");
    }
}
