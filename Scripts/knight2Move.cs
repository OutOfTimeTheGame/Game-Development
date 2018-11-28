using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight2Move : MonoBehaviour {
    //Kieran Lewis 2018 :)
    public GameObject knight2;
    public bool isLeft;
    public bool isRight;

    public float knight2Speed = 1.2f;
    public int knight2Health = 30;

    Animator anim;

	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        isLeft = true;
        isRight = false;	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isLeft == true)
        {
            anim.Play("knightLeft2");
            transform.Translate(new Vector2(-knight2Speed, 0) * Time.deltaTime * knight2Speed);
        }
        if (isRight == true)
        {
            anim.Play("knightRight2");
            transform.Translate(new Vector2(+knight2Speed, 0) * Time.deltaTime * knight2Speed);
        }

        if (knight2Health <= 5)
        {
            knight2Speed = 0.8f;
        }
        if (knight2Health <= 0)
        {
            Destroy(knight2);
            GameObject PS = GameObject.Find("Dean");
            PlayerScript pScript = PS.GetComponent<PlayerScript>();
            pScript.increaseScoreKnight2();
        }
		
	}

    public void loseHealthPistol()
    {
        knight2Health -= 5;
        
    }
    public void loseHealthRifle()
    {
        knight2Health -= 10;
    }
    public void loseHealthShotgun()
    {
        knight2Health -= 20;
    }
    public void loseHealthExplosion()
    {
        knight2Health -= 100;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
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
