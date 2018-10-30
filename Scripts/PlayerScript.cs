﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{


//Kieran Lewis 2018 :) 


    public GameObject deanAnderson;

    public float deanSpeed = 1.5f;
    public float deanJump = 5.0f;

    public double pistolAmmo;
    public int shotgunAmmo;
    public int assaultRifleAmmo;

    public bool isGrounded = false;
    public bool isMoving = false;

    public bool isRight = true;
    public bool isLeft = false;

    public bool hasHandgun;
    public bool hasShotgun;
    public bool hasAssaultRifle;

    public bool isUsingNoGun;
    public bool isUsingHandgun;
    public bool isUsingShotgun;
    public bool isUsingAssaultRifle;

    public bool hasPistolAmmo;
    public bool hasShotgunAmmo;
    public bool hasAssaultRifleAmmo;


    Animator anim;

    //To hold each of the weapons
    public GameObject pistolLeft;
    public GameObject pistolRight;

    public GameObject shotgunLeft;
    public GameObject shotgunRight;

    public GameObject assaultRifleLeft;
    public GameObject assaultRifleRight;

    //For the player's bullets






    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        isMoving = false;

        //The player will always have his handgun no matter what
        hasHandgun = true;
        hasShotgun = true;
        hasAssaultRifle = true;

        //Depending on the stance of Dean and if he has a gun out each gun's image will change respectivly 
        pistolLeft.SetActive(false);
        pistolRight.SetActive(false);

        assaultRifleRight.SetActive(false);
        assaultRifleLeft.SetActive(false);


        shotgunLeft.SetActive(false);
        shotgunRight.SetActive(false);

        //Deano starts the game using his fists. These booleans swap around when the player changes their weapon
        isUsingNoGun = true;
        isUsingHandgun = false;
        isUsingAssaultRifle = false;
        isUsingShotgun = false;

        //pistolAmmo += 20;
        //shotgunAmmo += 10;
        //assaultRifleAmmo += 40;

        hasPistolAmmo = true;
        hasShotgunAmmo = true;
        hasAssaultRifle = true;
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
        //Making sure the player has ammo for their weapons
        //Pistol
        if (pistolAmmo > 0)
        {
            hasPistolAmmo = true;
        }
        else
        {
            hasPistolAmmo = false;
        }
        //Assault Rifle
        if (assaultRifleAmmo > 0)
        {
            hasAssaultRifleAmmo = true;
        }
        else
        {
            hasAssaultRifleAmmo = false;
        }
        //Shotgun
        if(shotgunAmmo >0)
        {
            hasShotgunAmmo = true;
        }
        else
        {
            hasShotgunAmmo = false;
        }



        if (hasPistolAmmo == true && isUsingHandgun == true && isRight == true && Input.GetKeyUp(KeyCode.LeftControl))
        {
            //Call the pistol use right function and then deduct a bullet
            pistolUseRight();
            pistolAmmo--;
            Debug.Log(pistolAmmo);
        }

        if (hasPistolAmmo == true && isUsingHandgun == true && isLeft == true && Input.GetKeyUp(KeyCode.LeftControl))
        {
            //Call the pistol use left function and then deduct a bullet
            pistolUseLeft();
            pistolAmmo--;
            Debug.Log(pistolAmmo);
        }

        if (hasAssaultRifleAmmo == true && isUsingAssaultRifle == true && isRight == true && Input.GetKeyDown(KeyCode.LeftControl))
        {
            ARUseRight();
            assaultRifleAmmo--;
            Debug.Log(assaultRifleAmmo);
        }

        if (hasAssaultRifleAmmo == true && isUsingAssaultRifle == true && isLeft == true && Input.GetKeyDown(KeyCode.LeftControl))
        {
            ARUseLeft();
            assaultRifleAmmo--;
            Debug.Log(assaultRifleAmmo);
        }

        if (hasShotgunAmmo == true && isUsingShotgun == true && isLeft == true && Input.GetKeyDown(KeyCode.LeftControl))
        {
            SGUseLeft();
            shotgunAmmo--;
            Debug.Log(shotgunAmmo);
        }
        if (hasShotgunAmmo == true && isUsingShotgun == true && isRight == true && Input.GetKeyDown(KeyCode.LeftControl))
        {
            SGUseRight();
            shotgunAmmo--;
            Debug.Log(shotgunAmmo);
        }





        //Moving Left
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            anim.Play("MoveLeft");
            //If the player presses Left or A then they will move left
            transform.Translate(new Vector2(-deanSpeed, 0) * Time.deltaTime * deanSpeed);
            isMoving = true;
            anim.SetBool("hasStoppedLeft", false);
            isLeft = true;
            isRight = false;

        }

        if (Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.LeftArrow)))
        {
            //If the player lifts their finger from the left movement key, then they will stop moving and the animation will resort back to idle
            anim.Play("IdleLeft");
            isLeft = true;
            isRight = false;

        }

        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            anim.Play("MoveRight");
            //If the player presses Right or D then they will move Right
            transform.Translate(new Vector2(deanSpeed, 0) * Time.deltaTime * deanSpeed);
            isMoving = true;
            anim.SetBool("hasStoppedRight", false);
            isLeft = false;
            isRight = true;



        }

        if (Input.GetKeyUp(KeyCode.D) || (Input.GetKeyUp(KeyCode.RightArrow)))
        {
            //If the player lifts their finger from the right movement key, then they will stop moving and the animation will resort back to idle
            anim.Play("IdleRight");
            isLeft = false;
            isRight = true;
        }

        if (Input.GetKey(KeyCode.H))
        {


            isUsingNoGun = true;
            isUsingHandgun = false;
            isUsingAssaultRifle = false;
            isUsingShotgun = false;
        }

        if (Input.GetKey(KeyCode.Alpha1))
        {
            if (hasHandgun == true)
            {
                isUsingNoGun = false;
                isUsingHandgun = true;
                isUsingAssaultRifle = false;
                isUsingShotgun = false;
                usingPistol();

            }
        }

        if (Input.GetKey(KeyCode.Alpha2))
        {
            if (hasAssaultRifle == true)
            {
                isUsingNoGun = false;
                isUsingHandgun = false;
                isUsingAssaultRifle = true;
                isUsingShotgun = false;
                usingAssaultRifle();

            }
        }

        if (Input.GetKey(KeyCode.Alpha3))
        {
            if (hasShotgun == true)
            {
                isUsingNoGun = false;
                isUsingHandgun = false;
                isUsingAssaultRifle = false;
                isUsingShotgun = true;
                usingShotgun();

            }
        }


        if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.Space))))
        {

            if (isGrounded == true)
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.up * deanJump;
            }

        }

        if (isRight == true)
        {
            usingAGun();
        }

        if (isLeft == true)
        {
            usingAGun();
        }

        if (isUsingNoGun == true)
        {
            pistolLeft.SetActive(false);
            pistolRight.SetActive(false);

            assaultRifleRight.SetActive(false);
            assaultRifleLeft.SetActive(false);

            shotgunLeft.SetActive(false);
            shotgunRight.SetActive(false);
        }


    }


    public void usingAGun()
    {
        if (isUsingNoGun == true)
        {
            pistolLeft.SetActive(false);
            pistolRight.SetActive(false);

            assaultRifleRight.SetActive(false);
            assaultRifleLeft.SetActive(false);

            shotgunLeft.SetActive(false);
            shotgunRight.SetActive(false);
        }

        if (isUsingHandgun == true)
        {
            usingPistol();
        }
        if (isUsingAssaultRifle == true)
        {
            usingAssaultRifle();
        }
        if (isUsingShotgun == true)
        {
            usingShotgun();
        }
    }

    public void usingPistol()
    {
        if (isRight == true)
        {

            pistolLeft.SetActive(false);
            pistolRight.SetActive(true);

            assaultRifleRight.SetActive(false);
            assaultRifleLeft.SetActive(false);

            shotgunLeft.SetActive(false);
            shotgunRight.SetActive(false);
        }
        if (isLeft == true)
        {

            pistolLeft.SetActive(true);
            pistolRight.SetActive(false);

            assaultRifleRight.SetActive(false);
            assaultRifleLeft.SetActive(false);

            shotgunLeft.SetActive(false);
            shotgunRight.SetActive(false);
        }
    }

    public void usingShotgun()
    {
        if (isRight == true)
        {

            pistolLeft.SetActive(false);
            pistolRight.SetActive(false);

            assaultRifleRight.SetActive(false);
            assaultRifleLeft.SetActive(false);

            shotgunLeft.SetActive(false);
            shotgunRight.SetActive(true);
        }
        if (isLeft == true)
        {

            pistolLeft.SetActive(false);
            pistolRight.SetActive(false);

            assaultRifleRight.SetActive(false);
            assaultRifleLeft.SetActive(false);

            shotgunLeft.SetActive(true);
            shotgunRight.SetActive(false);
        }
    }

    public void usingAssaultRifle()
    {
        if (isRight == true)
        {

            pistolLeft.SetActive(false);
            pistolRight.SetActive(false);

            assaultRifleRight.SetActive(true);
            assaultRifleLeft.SetActive(false);

            shotgunLeft.SetActive(false);
            shotgunRight.SetActive(false);
        }
        if (isLeft == true)
        {

            pistolLeft.SetActive(false);
            pistolRight.SetActive(false);

            assaultRifleRight.SetActive(false);
            assaultRifleLeft.SetActive(true);

            shotgunLeft.SetActive(false);
            shotgunRight.SetActive(false);
        }
    }

    public void pistolUseRight()
    {

        GameObject PLR = GameObject.Find("plasmaLocationRight");
        ShootingScript shootScript = PLR.GetComponent<ShootingScript>();
        shootScript.shootRight();

    }

    public void pistolUseLeft()
    {


        GameObject PLL = GameObject.Find("plasmaLocationLeft");
        ShootingScript shootScript = PLL.GetComponent<ShootingScript>();
        shootScript.shootLeft();
    }

    public void ARUseLeft()
    {
        //this needs changed for AR and Shotgun
        GameObject PLL = GameObject.Find("plasmaLocationLeft");
        ShootingScript shootScript = PLL.GetComponent<ShootingScript>();
        shootScript.ARShootLeft();
    }

    public void ARUseRight()
    {
        //this needs changed for AR and Shotgun
        GameObject PLL = GameObject.Find("plasmaLocationLeft");
        ShootingScript shootScript = PLL.GetComponent<ShootingScript>();
        shootScript.ARShootRight();
    }

    public void SGUseLeft()
    {
        //this needs changed for AR and Shotgun
        GameObject PLL = GameObject.Find("plasmaLocationLeft");
        ShootingScript shootScript = PLL.GetComponent<ShootingScript>();
        shootScript.ShotgunShootLeft();
    }

    public void SGUseRight()
    {
        //this needs changed for AR and Shotgun
        GameObject PLL = GameObject.Find("plasmaLocationLeft");
        ShootingScript shootScript = PLL.GetComponent<ShootingScript>();
        shootScript.ShotgunShootRight();
    }

    //For Exiting Levels and jumping
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "jumpCollider")
        {
            Debug.Log("Jump True");
            isGrounded = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "jumpCollider")
        {
            Debug.Log("Jump True");
            isGrounded = false;
        }
    }

}