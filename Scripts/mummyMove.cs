using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mummyMove : MonoBehaviour {

    //Kieran Lewis 2018 :)
    //Declaring that we are using the animator
    Animator anim;

    public float mummyMoveSpeed = 0.50f;
    public GameObject mummy;
    //Handgun does 5 damage to each enemy
    //Shotgun does 20 damage to each enemy
    //Rifle does 10 damage to each enemy
    public int mummyHealth = 10;

    public bool mummyMovingLeft;
    public bool mummyMovingRight;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        //the mummy will start off by moving left
        mummyMovingLeft = true;
        //the mummy won't be moving right on startup
        mummyMovingRight = false;

	}
	
	// Update is called once per frame
	void Update ()
    {
        //if the mummy is moving left then 
        if (mummyMovingLeft == true)
        {
            anim.Play("mummyWalkLeft");
            //this not only move the mummy but also matches it to the Framerate of the game
            transform.Translate(new Vector2(-mummyMoveSpeed, 0) * Time.deltaTime * mummyMoveSpeed);
        }
        //if the mummy is moving left then
        if (mummyMovingRight == true)
        {
            anim.Play("mummyWalkRight");
            //this not only move the mummy but also matches it to the Framerate of the game
            transform.Translate(new Vector2(+mummyMoveSpeed, 0) * Time.deltaTime * mummyMoveSpeed);
        }

        if (mummyHealth <=0)
        {   
            //kill the mummy within a time frame
            Destroy(mummy);
            GameObject PS = GameObject.Find("Dean");
            PlayerScript pScript = PS.GetComponent<PlayerScript>();
            pScript.increaseScoreMummy();
        }
    }

    public void loseHealthPistol()
    {
        mummyHealth -= 5;
    }
    public void loseHealthRifle()
    {
        mummyHealth -= 10;
    }
    public void loseHealthShotgun()
    {
        mummyHealth -= 20;
    }

    public void loseHealthExplosion()
    {
        mummyHealth-=100;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //If the mummy walks against the left zone then they will turn around and walk to the right zone.
        //If the mummy walks against the right zone then they will turn around and walk to the left zone.

        if (collision.gameObject.tag == "zoneLeft")
        {
            mummyMovingLeft = false;
            mummyMovingRight = true;
        }

        if (collision.gameObject.tag == "zoneRight")
        {
            mummyMovingLeft = true;
            mummyMovingRight = false;
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
        if (collision.gameObject.tag == "Explosion")
        {
            loseHealthExplosion();
        }

    }
}
