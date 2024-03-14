using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public SpriteRenderer sprite;
    public EnemyData data;
    public Deck singleton;
    public J_LevelManager lev;
    public float weight, health;
    public Camera _camera;

    private void Awake()
    {
        weight = data.spawnWeight;
        sprite.color = data.color;
    }

    private void Start()
    {
        _camera = FindObjectOfType<Camera>();
        singleton = FindObjectOfType<Deck>();
        lev = FindObjectOfType<J_LevelManager>();
        health = data.health;
    }

    private void Update()
    {
        if (   (_camera.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono).x > transform.position.x - .5f)
            && (_camera.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono).x < transform.position.x + .5f)
            && (_camera.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono).y > transform.position.y - 1) 
            && (_camera.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono).y < transform.position.y + 1)
            )
        {
            if (Input.GetMouseButtonDown(0))
            {
                singleton.enemy = this;
            }
        }

        if (singleton.enemy == this)
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
}
