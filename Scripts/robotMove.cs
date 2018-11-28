using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotMove : MonoBehaviour
{
    //Kieran Lewis 2018
    Animator anim;

    public float robotMoveSpeed = 1.8f;

    public GameObject robot;

    public GameObject rifleLeft;
    public GameObject rifleRight;

    public int robotHealth = 50;

    public bool isLeft;
    public bool isRight;


	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();

        isLeft = true;
        isRight = false;
        rifleLeft.SetActive(true);
        rifleRight.SetActive(false);	
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isLeft == true)
        {
            rifleLeft.SetActive(true);
            rifleRight.SetActive(false);
            anim.Play("robotLeft");
            transform.Translate(new Vector2(-robotMoveSpeed, 0) * Time.deltaTime * robotMoveSpeed);
        }
        if (isRight == true)
        {
            rifleLeft.SetActive(false);
            rifleRight.SetActive(true);
            anim.Play("robotRight");
            transform.Translate(new Vector2(robotMoveSpeed, 0) * Time.deltaTime * robotMoveSpeed);
        }
        if (robotHealth <=20)
        {
            robotMoveSpeed = 1.00f;
        }
        if (robotHealth <= 10)
        {
            robotMoveSpeed = 0.5f;
        }
        if (robotHealth <= 0)
        {
            Destroy(robot);
            GameObject PS = GameObject.Find("Dean");
            PlayerScript pScript = PS.GetComponent<PlayerScript>();
            pScript.increaseScoreRobot();
        }
	}
    public void loseHealthPistol()
    {
        robotHealth -= 5;
       
    }
    public void loseHealthRifle()
    {
        robotHealth -= 10;
    }
    public void loseHealthShotgun()
    {
        robotHealth -= 20;
    }
    public void loseHealthExplosion()
    {
        robotHealth -= 100;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //If the robot walks against the left zone then they will turn around and walk to the right zone.
        //If the robot walks against the right zone then they will turn around and walk to the left zone.

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

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "jumpCollider")
        {
            transform.parent = collision.transform;
        }
    }
}
