using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class TheDeck : MonoBehaviour
{
    public Deck data;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(data.DrawCard);
    }
}
