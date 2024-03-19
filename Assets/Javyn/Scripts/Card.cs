using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;


public class Card : MonoBehaviour
{
    public CardBase data;
    public Image image;
    public TextMeshProUGUI tCardName, tManaCost, tDamage, tDescription;
    //public Image image, glow;
    public Deck singleton;
    public int why, damage, manaCost;

    void Start()
    {
        why = (int) transform.position.y;
    }
    
    void Update()
    {
        if (data != null)
        {
            transform.position = new Vector3(transform.position.x, why, transform.position.z);
            gameObject.SetActive(true);
            damage = data.damage;
            manaCost = data.manaCost;
            #region CardData

            tCardName.text = data.cardName;
            tManaCost.text = data.manaCost.ToString();
            tDamage.text = data.damage.ToString();
            tDescription.text = data.description;
            
            data.ChangeColorBasedOnType(image);

            #endregion
        }
        else
        {
            transform.position = new Vector3(transform.position.x, -1000, transform.position.z);
        }
        
        /*
        if ((Input.mousePosition.x > transform.position.x - 50 && Input.mousePosition.x < transform.position.x + 50) && (Input.mousePosition.y > transform.position.y - 75 && Input.mousePosition.y < transform.position.y + 75))
        {
            if (Input.GetMouseButtonDown(0))
            {
                singleton.selected = this;
            }
        }
        
    
        if (singleton.selected == this)
        {
            glow.color = new Color(1, 1, 0, 1);
        }

        else
        {
            glow.color = new Color(0, 0, 0, 0);
        }
        */
    }
}