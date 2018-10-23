using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DeanControls : MonoBehaviour
//Kieran Lewis 2018 :) 
{

    public GameObject deanAnderson;

    public float deanSpeed = 1.5f;
    public float deanJump = 5.0f;
    public bool isGrounded = true;
    public bool isMoving = false;

    public bool hasHandgun;
    public bool hasShotgun;
    public bool hasAssaultRifle;
    Animator anim;



	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        isMoving = false;
	}
	
	// Update is called once per frame
	

    public void idleLeft()
    {
        anim.SetBool("hasStoppedLeft", true);
    }

    public void idleRight()
    {
        anim.SetBool("hasStoppedRight", true);
    }

    void Update()
    {
        //Moving Left
        while (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            anim.Play("MoveLeft");
            //If the player presses Left or A then they will move left
            transform.Translate(new Vector2(-deanSpeed, 0) * Time.deltaTime * deanSpeed);
            isMoving = true;
            anim.SetBool("hasStoppedLeft", false);
        }

        while (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            anim.Play("MoveRight");
            //If the player presses Right or D then they will move Right
            transform.Translate(new Vector2(deanSpeed, 0) * Time.deltaTime * deanSpeed);
            isMoving = true;
            anim.SetBool("hasStoppedRight", false);
        }
    }

    //For Exiting Levels
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
