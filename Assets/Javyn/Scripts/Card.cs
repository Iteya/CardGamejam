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
        Debug.Log("Start: " + why);
    }
    
    void Update()
    {
        if (data != null)
        {
            Debug.Log("After: " + why);
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
    }
}