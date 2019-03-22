﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    [SerializeField]
    protected int maxHealth = 3;
    protected int health;

    private Audiobank ab;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        ab = gameObject.GetComponent<Audiobank>();
    }

    void Update()
    {
        if (health <= 0) {
            ab.PlayOnce();
            Destroy(gameObject);
            OnDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            health -= other.gameObject.GetComponent<Bullet>().damage;
        }
    }

    protected virtual void OnDeath()
    {

    } 
}
