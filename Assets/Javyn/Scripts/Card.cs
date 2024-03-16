using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;


public class Card : MonoBehaviour
{
    public CardBase data;
    public TextMeshProUGUI tCardName, tManaCost, tDamage, tDescription;
    public Image image, glow;
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

            if (data.type == CardType.Poison)
            {
                image.color = new Color(0.561f, 0.737f, 0.561f);
            }
            else if (data.type == CardType.Fire)
            {
                image.color = new Color(1, 0.278f, 0.278f);
            }
            else if (data.type == CardType.Normal)
            {
                image.color = new Color(0.737f, 0.682f, 0.682f);
            }

            #endregion
        }
        else
        {
            transform.position = new Vector3(transform.position.x, -1000, transform.position.z);
        }

        //TODO make card selectable;
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
    }
}