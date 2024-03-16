using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hourglass : MonoBehaviour
{
    public Deck data;
    public int energy, max;
    public TextMeshProUGUI total, current;
    public Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(data.EndTurn);
    }

    // Update is called once per frame
    void Update()
    {
        total.text = max.ToString();
        current.text = energy.ToString();
    }
}
