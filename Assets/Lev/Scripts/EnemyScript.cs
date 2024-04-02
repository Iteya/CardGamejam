using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    [Header("Libraries")]
    public HealthBarScript healthBar;
    public EnemyData data;
    public LevDeck singleton;
    public J_LevelManager lev; // why my name here?
    public new Camera camera;
    public SpriteRenderer sprite;
    public PlayerScript player;
    
    [Header("Internals")]
    public float weight;
    public int health;
    public int energy;
    
    
    [Header("Action Variables")]
    public List<CardBase> actions;

    private void Awake()
    {
        weight = data.spawnWeight;
        sprite.color = data.color;
    }

    private void Start()
    {
        camera = FindObjectOfType<Camera>();
        singleton = FindObjectOfType<LevDeck>();
        lev = FindObjectOfType<J_LevelManager>();
        player = FindObjectOfType<PlayerScript>();
        singleton.enemies++;
        health = data.health;
        healthBar.SetMaxHealth(health);
    }

    private void Update()
    {
        /*
        if (singleton.chooseActions > 0)
        {
            ChooseActions(energy);
            singleton.chooseActions--;
        }

        if (singleton.startIEnumerator > 0)
        {
            Actions();
            singleton.startIEnumerator--;
        }
        */
        
        if (   (camera.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono).x > transform.position.x - .5f)
            && (camera.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono).x < transform.position.x + .5f)
            && (camera.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono).y > transform.position.y - 1) 
            && (camera.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono).y < transform.position.y + 1)
            )
        {
            if (Input.GetMouseButtonDown(0))
            {
                singleton.selectedEnemy = this;
            }
        } else if (Input.GetMouseButtonDown(0) && singleton.selectedEnemy == this)
        {
            singleton.selectedEnemy = null;
        }

        if (singleton.selectedEnemy == this)
        {
            //TODO update selection uX
            transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (health <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        Destroy(gameObject);
    }
    
    public void ChangeHealth(int amount)
    {
        health += amount;
        
        healthBar.SetHealth(health);
    }


    public void ChooseActions(int maxEnergy)
    {
        int i = 0;
        
        while (maxEnergy > 1 && i < 2) // if it keeps getting cards with 0 cost, it an only get 2 cards at max
        {
            CardBase chosenAction = data.ActionChoices[Random.Range(0, data.ActionChoices.Count)];
            if (maxEnergy - chosenAction.manaCost > 0)
            {
                actions.Add(chosenAction);
            }

            i++;
        }
        
    }

    public void Actions()
    {
        for (int i = 0; i < actions.Count; i++)
        {
            player.ChangeHealth(-actions[i].damage);
        }
        actions.RemoveRange(0, actions.Count);
    }
    
}
