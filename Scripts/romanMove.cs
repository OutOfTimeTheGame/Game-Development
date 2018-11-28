using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class romanMove : MonoBehaviour
{
    //Kieran Lewis 2018 :)
    public GameObject roman;

    Animator anim;

    //Speed of the roman
    public float romanSpeed = 1.4f;
    //the roman's health is 30
    public int romanHealth = 30;
    //booleans for if they are moving left or right
    public bool isLeft;
    public bool isRight;
    //booleans for if they are attacking left or right
    public bool isAttackingLeft;
    public bool isAttackingRight;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        isLeft = true;
        isRight = false;

        isAttackingLeft = false;
        isAttackingRight = false;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isLeft == true)
        {
            anim.Play("romanLeft");
            transform.Translate(new Vector2(-romanSpeed, 0) * Time.deltaTime * romanSpeed);
        }
        if (isRight == true)
        {
            anim.Play("romanRight");
            transform.Translate(new Vector2(+romanSpeed, 0) * Time.deltaTime * romanSpeed);
        }
        if (romanHealth <= 15)
        {
            romanSpeed = 1.00f;
        }
        if (romanHealth <= 5)
        {
            romanSpeed = 0.6f;
        }
        if (romanHealth <= 0)
        {
            Destroy(roman);
            GameObject PS = GameObject.Find("Dean");
            PlayerScript pScript = PS.GetComponent<PlayerScript>();
            pScript.increaseScoreRoman1();
        }
	}

    public void loseHealthPistol()
    {
        romanHealth -= 5;
    }
    public void loseHealthRifle()
    {
        romanHealth -= 10;
    }
    public void loseHealthShotgun()
    {
        romanHealth -= 20;
    }
    public void loseHealthExplosion()
    {
        romanHealth -= 100;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //If the roman walks against the left zone then they will turn around and walk to the right zone.
        //If the roman walks against the right zone then they will turn around and walk to the left zone.

        if (collision.gameObject.tag == "zoneLeft")
        {
            isLeft = false;
            isRight = true;
        }

        if (collision.gameObject.tag == "zoneRight")
        {
            isLeft = true;
            isRight = false;
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
