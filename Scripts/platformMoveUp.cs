using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMoveUp : MonoBehaviour {
    //Kieran Lewis 2018 :)
    public float platformMoveSpeed = 1.5f;
    public bool movingUp;
    public bool movingDown;

	// Use this for initialization
	void Start ()
    {
        movingUp = true;
        movingDown = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (movingUp == true)
        {
            transform.Translate(new Vector2(0, +platformMoveSpeed) * Time.deltaTime * platformMoveSpeed);   
        }

        if (movingDown == true)
        {
            transform.Translate(new Vector2(0, -platformMoveSpeed) * Time.deltaTime * platformMoveSpeed);
        }
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "zoneUp")
        {
            movingUp = false;
            movingDown = true;
        }
        if (collision.gameObject.tag == "zoneDown") 
        {
            movingUp = true;
            movingDown = false;
        }
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dean")
        {
            
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dean")
        {
           
        }
    } 

}
