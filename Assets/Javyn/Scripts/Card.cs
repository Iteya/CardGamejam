using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;


public class Card : MonoBehaviour
{
    public CardBase data;
    public TextMeshProUGUI tCardName, tManaCost, tDamage, tDescription;
    public Image image, glow;

    void Update()
    {
        #region CardData
        tCardName.text = data.cardName;
        tManaCost.text = data.manaCost.ToString();
        tDamage.text = data.damage.ToString();
        tDescription.text = data.description;

        if (data.type == CardType.Poison)
        {
            image.color = new Color(0.561f,0.737f,0.561f);
        } else if (data.type == CardType.Fire)
        {
            image.color = new Color(1,0.278f,0.278f);
        } else if (data.type == CardType.Normal)
        {
            image.color = new Color(0.737f,0.682f,0.682f);
        }
        #endregion
        
        //TODO make card selectable;
        if (Input.mousePosition.x > transform.position.x - 50 && Input.mousePosition.x < transform.position.x + 50)
        {
            glow.color = new Color(1, 1, 0, 1);
        }
        else
        {
            glow.color = new Color(0, 0, 0, 0);
        }


        Debug.Log(transform.position.x);
        Debug.Log(Input.mousePosition.x);
    }
}