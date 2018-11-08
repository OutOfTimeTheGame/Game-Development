﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightMove : MonoBehaviour {
    Animator anim;

    public int knightHealth = 25;
    public float knightSpeed = 0.8f;

    public bool knightMoveLeft;
    public bool knightMoveRight;

    public GameObject knight;
    
	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        knightMoveLeft = false;
        knightMoveRight = true;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (knightMoveLeft == true)
        {
            anim.Play("knightLeft");
            transform.Translate(new Vector2(-knightSpeed, 0) * Time.deltaTime * knightSpeed);
        }

        if (knightMoveRight == true)
        {
            anim.Play("knightRight");
            transform.Translate(new Vector2(+knightSpeed, 0) * Time.deltaTime * knightSpeed);
        }

        if (knightHealth <= 0)
        {
            
            Destroy(knight, 0.03f);
        }
    }

    public void loseHealthPistol()
    {
        Debug.Log(knightHealth);
        knightHealth -= 5;
        
    }

    public void loseHealthRifle()
    {
        knightHealth -= 10;
    }

    public void loseHealthShotgun()
    {
        knightHealth -= 20;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //If the mummy walks against the left zone then they will turn around and walk to the right zone.
        //If the mummy walks against the right zone then they will turn around and walk to the left zone.

        if (collision.gameObject.tag == "zoneLeft")
        {
            knightMoveLeft = false;
            knightMoveRight = true;
        }

        if (collision.gameObject.tag == "zoneRight")
        {
            knightMoveLeft = true;
            knightMoveRight = false;
        }

        if (collision.gameObject.tag == "pistolBullet")
        {

            loseHealthPistol();

        }

        if (collision.gameObject.tag == "shotgunShell")
        {

            loseHealthShotgun();

        }

        if (collision.gameObject.tag == "rifleBullet")
        {

            loseHealthRifle();

        }

    }
}
