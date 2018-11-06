using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pharoahMove : MonoBehaviour {

    //Kieran Lewis 2018 :) 
    //Declaring use of the animator
    Animator anim;

    public float pharoahMoveSpeed = 1f;
    public GameObject pharoah1;
    //Handgun does 5 damage to each enemy
    //Shotgun does 20 damage to each enemy
    //Rifle does 10 damage to each enemy
    public int pharoahHealth = 15;

    public bool pharoahMovingLeft;
    public bool pharoahMovingRight;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
        //The pharoah, like the mummy, will start by facing left
        pharoahMovingLeft = true;
        pharoahMovingRight = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (pharoahMovingLeft == true)
        {
            anim.Play("pharoahLeft");
            transform.Translate(new Vector2(-pharoahMoveSpeed, 0) * Time.deltaTime * pharoahMoveSpeed);
        }

        if (pharoahMovingRight == true)
        {
            anim.Play("pharoahRight");
            transform.Translate(new Vector2(+pharoahMoveSpeed, 0) * Time.deltaTime * pharoahMoveSpeed);
        }

        if (pharoahHealth <= 5)
        {
            //If the pharoah loses too much health then they will move slower
            pharoahMoveSpeed = 0.75f;
        }

        if (pharoahHealth <= 0)
        {
            Destroy(pharoah1, 0.02f);
        }
    }

    public void loseHealthPistol()
    {
        pharoahHealth -= 5;
    }
    public void loseHealthRifle()
    {
        pharoahHealth -= 10;
    }
    public void loseHealthShotgun()
    {
        pharoahHealth -= 20;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //If the mummy walks against the left zone then they will turn around and walk to the right zone.
        //If the mummy walks against the right zone then they will turn around and walk to the left zone.

        if (collision.gameObject.tag == "zoneLeft")
        {
            pharoahMovingLeft = false;
            pharoahMovingRight = true;
        }

        if (collision.gameObject.tag == "zoneRight")
        {
            pharoahMovingLeft = true;
            pharoahMovingRight = false;
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
