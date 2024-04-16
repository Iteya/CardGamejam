using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public HealthBarScript healthBar;
    public LevDeck singleton;

    void Start()
    {
        singleton = FindObjectOfType<LevDeck>();
        maxHealth = singleton.maxHealth;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }

    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        
        healthBar.SetHealth(currentHealth);
    }
}
