using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public HealthBarScript healthBar;
    
    public SpriteRenderer sprite;
    public EnemyData data;
    public LevDeck singleton;
    public J_LevelManager lev; // why my name here?
    public float weight;
    public int health;
    public new Camera camera;

    private void Awake()
    {
        weight = data.spawnWeight;
        sprite.color = data.color;
    }

    private void Start()
    {
        health = data.health;
        healthBar.SetMaxHealth(health);
        camera = FindObjectOfType<Camera>();
        singleton = FindObjectOfType<LevDeck>();
        lev = FindObjectOfType<J_LevelManager>();
    }
    
    

    private void Update()
    {
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
            sprite.color = Color.yellow;
        }
        else
        {
            sprite.color = data.color;
        }

        if (health <= 0)
        {
            lev.numEnemiesSpawned -= 1;
            Destroy(this.gameObject);
        }
    }
    
    
    
    public void ChangeHealth(int amount)
    {
        health += amount;
        
        healthBar.SetHealth(health);
    }
    
    
}
