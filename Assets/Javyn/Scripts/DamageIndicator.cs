using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{
    public TextMeshProUGUI text;

    public Image image;
    
    public int damage;

    void Update()
    {
        if (damage == 0)
        {
            text.color = Color.clear;
            image.color = Color.clear;
        }

        if (damage != 0)
        {
            text.color = Color.black;
            image.color = new Color(0.737f, 0.682f, 0.682f);
        }

        text.text = damage.ToString();
    }
}
