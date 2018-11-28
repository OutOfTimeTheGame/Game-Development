using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{


    //Kieran Lewis 2018 :) 

    
    //Storing a reference to the player as an object
    public GameObject deanAnderson;
    //This is the player's speed
    public float deanSpeed = 1.5f;
    //The player's jump speed
    public float deanJump = 5.0f;


    //Variables for each of the ammo types the player has
    public int pistolAmmo;
    public int shotgunAmmo;
    public int assaultRifleAmmo;
    public int rockets;

    //a text reference for the ammo so that it can display on the HUD
    public Text pistolAmmoText;
    public Text shotgunAmmoText;
    public Text assaultRifleAmmoText;
    public Text rocketsText;

    //A boolean confirming whether the player is on the ground
    public bool isGrounded = false;
    //Isn't needed anymore
    public bool isMoving = false;

    //Checking which way the player is facing
    public bool isRight = true;
    public bool isLeft = false;


    //booleans to see if player has the weapons
    public bool hasHandgun;
    public bool hasShotgun;
    public bool hasAssaultRifle;
    public bool hasRPG;

    //booleans to see if the player is using a specific weapon
    public bool isUsingNoGun;
    public bool isUsingHandgun;
    public bool isUsingShotgun;
    public bool isUsingAssaultRifle;
    public bool isUsingRPG;

    //booleans to see if the player has these ammo types
    public bool hasPistolAmmo;
    public bool hasShotgunAmmo;
    public bool hasAssaultRifleAmmo;
    public bool hasRockets;

    //Caling the Animator
    Animator anim;

    //To hold each of the weapons
    public GameObject pistolLeft;
    public GameObject pistolRight;

    public GameObject shotgunLeft;
    public GameObject shotgunRight;

    public GameObject assaultRifleLeft;
    public GameObject assaultRifleRight;

    public GameObject RPGLeft;
    public GameObject RPGRight;

    public GameObject RPGLeftNoAmmo;
    public GameObject RPGRightNoAmmo;


    //To hold each weapon HUD element
    public GameObject weaponArea;
    public GameObject pistolPortrait;
    public GameObject shotgunPortrait;
    public GameObject AssaultRiflePortrait;
    public GameObject RPGPortrait;

    public Rigidbody2D rb2;

    //Assault Rifle Firerate
    public float fireRateAR = 0.08f;
    public float fire = 0.0f;
    //Shotgun Firerate
    public float fireRateSG = 0.55f;
    //RPG Firerate
    public float fireRateRPG = 0.69f;

    //Health
    public int maxHealth;
    public int minHealth;
    public int currentHealth;
    public Slider healthSlider;

    //Score
    public int score;
    public Text scoreText;

    //Gameover screen for the player
    public GameObject Gameover;
    public AudioClip pistolShot;
    public AudioClip ARShot;
    public AudioClip ShotgunShot;
    public AudioClip RPGShot;
    public AudioClip Hurt;
    public AudioClip Death;
    public AudioClip RPGLaugh;
    public AudioClip health;
    public AudioClip ammo;
    



    void Awake()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        
        string sceneName = currentScene.name;
        //When Level 2, 3 and 4 start gain the user information from Player Prefs.
        if (sceneName == "Level2" || sceneName == "Level3" || sceneName == "Level4")
        {
            score = PlayerPrefs.GetInt("scoreText");
            pistolAmmo = PlayerPrefs.GetInt("pistolAmmoText");
            assaultRifleAmmo = PlayerPrefs.GetInt("assaultRifleAmmoText");
            shotgunAmmo = PlayerPrefs.GetInt("shotgunAmmoText");
            rockets = PlayerPrefs.GetInt("rocketsText");
        }
    }

    // Use this for initialization
    void Start()
    {
        //obtaining the current scene
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        anim = GetComponent<Animator>();

        rb2 = GetComponent<Rigidbody2D>();

        isMoving = false;

        //The player will always have his handgun no matter what
        hasHandgun = true;
        if (sceneName == "Level2")
        {
            hasShotgun = true;
        }

        if (sceneName == "Level3")
        {
            hasAssaultRifle = true;
            hasShotgun = true;
        }
        if (sceneName == "Level4")
        {
            hasRPG = true;
            hasAssaultRifle = true;
            hasShotgun = true;
        }

        hasShotgun = false;
        hasAssaultRifle = false;
        hasRPG = false;

        //Depending on the stance of Dean and if he has a gun out each gun's image will change respectivly 
        pistolLeft.SetActive(false);
        pistolRight.SetActive(false);

        assaultRifleRight.SetActive(false);
        assaultRifleLeft.SetActive(false);


        shotgunLeft.SetActive(false);
        shotgunRight.SetActive(false);

        RPGLeft.SetActive(false);
        RPGRight.SetActive(false);

        RPGLeftNoAmmo.SetActive(false);
        RPGRightNoAmmo.SetActive(false);
        //Deano starts the game using his fists. These booleans swap around when the player changes their weapon
        isUsingNoGun = true;
        isUsingHandgun = false;
        isUsingAssaultRifle = false;
        isUsingShotgun = false;
        isUsingRPG = false;
        //If Level 1 has loaded then all ammo will be at its basic values
        if (sceneName == "Level1")
        {
            pistolAmmo += 20;
            shotgunAmmo += 10;
            assaultRifleAmmo += 40;
            rockets += 3;
        }
        

        hasPistolAmmo = true;
        hasShotgunAmmo = true;
        hasAssaultRifleAmmo = true;
        hasRockets = true;

        //Preparing the Score 
        scoreText.text = "Score: " + score;

        if (sceneName == "Level1")
        {
            score = 0;
        }

        //Preparing the ammo HUD
        //create a reference to the text of each ammo
        pistolAmmoText.text = "AMMO: " + pistolAmmo;
        shotgunAmmoText.text = "AMMO: " + shotgunAmmo;
        assaultRifleAmmoText.text = "AMMO: " + assaultRifleAmmo;
        rocketsText.text = "AMMO: " + rockets;

        //Hide all of the ammo counters on startup
        pistolAmmoText.GetComponent<Text>().enabled = false;
        shotgunAmmoText.GetComponent<Text>().enabled = false;
        assaultRifleAmmoText.GetComponent<Text>().enabled = false;
        rocketsText.GetComponent<Text>().enabled = false;

        weaponArea.SetActive(false);
        pistolPortrait.SetActive(false);
        shotgunPortrait.SetActive(false);
        AssaultRiflePortrait.SetActive(false);
        RPGPortrait.SetActive(false);

        //Preparing the health for each level
        if (sceneName == "Level1")
        {
            maxHealth = 100;
            minHealth = 0;
            currentHealth = maxHealth;
        }

        if (sceneName == "Level2")
        {
            maxHealth = 125;
            minHealth = 0;
            currentHealth = maxHealth;
            hasShotgun = true;
            DontDestroyOnLoad(pistolAmmoText);
            DontDestroyOnLoad(scoreText);
        }

        if (sceneName == "Level3")
        {
            maxHealth = 150;
            minHealth = 0;
            currentHealth = maxHealth;
            hasShotgun = true;
            hasAssaultRifle = true;
        }

        if (sceneName == "Level4")
        {
            maxHealth = 200;
            minHealth = 0;
            currentHealth = maxHealth;
            hasShotgun = true;
            hasAssaultRifle = true;
            hasRPG = true;
        }

        healthSlider.value = currentHealth;

      
    }

    public void enemyDamage()
    {
        currentHealth -= 10;
        healthSlider.value = currentHealth;
    }

    //If the player has stopped then they will use the idle left animation
    public void idleLeft()
    {
        anim.SetBool("hasStoppedLeft", true);
    }
    //If the player has stopped then they will use the idle right animation
    public void idleRight()
    {
        anim.SetBool("hasStoppedRight", true);
    }
    //If the player dies then the game will pause and dean will not be active anymore
    public void PlayerDeath()
    {
        Time.timeScale = 0f;
        deanAnderson.SetActive(false);
        Gameover.SetActive(true);
        AudioSource.PlayClipAtPoint(Death, Camera.main.transform.position);
    }

    void Update()
    {
        //The player's controls
        //If the player's health is below the minimum health then they will die
            if (currentHealth <= minHealth)
            {
            
            PlayerDeath();

            }

       

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
            if (shotgunAmmo > 0)
            {
                hasShotgunAmmo = true;
            }
            else
            {
                hasShotgunAmmo = false;
            }
            if (rockets > 0)
            {
                hasRockets = true;
            }
            else
            {
                hasRockets = false;
            }


            


            //Keyboard Controlling Shooting
            if (hasPistolAmmo == true && isUsingHandgun == true && isRight == true && Input.GetKeyUp(KeyCode.LeftControl))
            {
                //Call the pistol use right function and then deduct a bullet
                pistolUseRight();
                pistolAmmo--;
                pistolAmmoText.text = "AMMO: " + pistolAmmo;
                Debug.Log(pistolAmmo);
            }

            if (hasPistolAmmo == true && isUsingHandgun == true && isLeft == true && Input.GetKeyUp(KeyCode.LeftControl))
            {
                //Call the pistol use left function and then deduct a bullet
                pistolUseLeft();
                pistolAmmo--;
                pistolAmmoText.text = "AMMO: " + pistolAmmo;
                Debug.Log(pistolAmmo);
            }

            if (Time.time > fire && hasAssaultRifleAmmo == true && isUsingAssaultRifle == true && isRight == true && Input.GetKey(KeyCode.LeftControl))
            {
                fire = Time.time + fireRateAR;
                ARUseRight();
                assaultRifleAmmo--;
                assaultRifleAmmoText.text = "AMMO: " + assaultRifleAmmo;
                Debug.Log(assaultRifleAmmo);
            }

            if (Time.time > fire && hasAssaultRifleAmmo == true && isUsingAssaultRifle == true && isLeft == true && Input.GetKey(KeyCode.LeftControl))
            {
                fire = Time.time + fireRateAR;
                ARUseLeft();
                assaultRifleAmmo--;
                assaultRifleAmmoText.text = "AMMO: " + assaultRifleAmmo;
                Debug.Log(assaultRifleAmmo);
            }

            if (Time.time > fire && hasShotgunAmmo == true && isUsingShotgun == true && isLeft == true && Input.GetKeyDown(KeyCode.LeftControl))
            {
                fire = Time.time + fireRateSG;
                SGUseLeft();
                shotgunAmmo--;
                shotgunAmmoText.text = "AMMO: " + shotgunAmmo;
                Debug.Log(shotgunAmmo);
            }
            if (Time.time > fire && hasShotgunAmmo == true && isUsingShotgun == true && isRight == true && Input.GetKeyDown(KeyCode.LeftControl))
            {
                fire = Time.time + fireRateSG;
                SGUseRight();
                shotgunAmmo--;
                shotgunAmmoText.text = "AMMO: " + shotgunAmmo;
                Debug.Log(shotgunAmmo);
            }

            if (Time.time > fire && hasRockets == true && isUsingRPG == true && isLeft == true && Input.GetKey(KeyCode.LeftControl))
            {
                fire = Time.time + fireRateRPG;
                RPGUseLeft();
                rockets--;
                rocketsText.text = "AMMO: " + rockets;
                Debug.Log(rockets);
            }

            if (Time.time > fire && hasRockets == true && isUsingRPG == true && isRight == true && Input.GetKey(KeyCode.LeftControl))
            {
                fire = Time.time + fireRateRPG;
                RPGUseRight();
                rockets--;
                rocketsText.text = "AMMO: " + rockets;
                Debug.Log(rockets);
            }

            //Mouse Controlling Shooting
            if (hasPistolAmmo == true && isUsingHandgun == true && isRight == true && Input.GetKeyUp(KeyCode.Mouse0))
            {
                //Call the pistol use right function and then deduct a bullet
                pistolUseRight();
                pistolAmmo--;
                pistolAmmoText.text = "AMMO: " + pistolAmmo;
                Debug.Log(pistolAmmo);
            }

            if (hasPistolAmmo == true && isUsingHandgun == true && isLeft == true && Input.GetKeyUp(KeyCode.Mouse0))
            {
                //Call the pistol use left function and then deduct a bullet
                pistolUseLeft();
                pistolAmmo--;
                pistolAmmoText.text = "AMMO: " + pistolAmmo;
                Debug.Log(pistolAmmo);
            }

            if (Time.time > fire && hasAssaultRifleAmmo == true && isUsingAssaultRifle == true && isRight == true && Input.GetKey(KeyCode.Mouse0))
            {
                //Call the Assault Rifle use Left fucntion and then deduct a bullet
                //This adds a firerate to the Assault Rifle by only allowing it to fire when the timer resets essentially
                fire = Time.time + fireRateAR;
                ARUseRight();
                assaultRifleAmmo--;
                assaultRifleAmmoText.text = "AMMO: " + assaultRifleAmmo;
                Debug.Log(assaultRifleAmmo);
            }

            if (Time.time > fire && hasAssaultRifleAmmo == true && isUsingAssaultRifle == true && isLeft == true && Input.GetKey(KeyCode.Mouse0))
            {
                //Call the Assault Rifle use Right fucntion and then deduct a bullet
                //This adds a firerate to the Assault Rifle by only allowing it to fire when the timer resets essentially
                fire = Time.time + fireRateAR;
                ARUseLeft();
                assaultRifleAmmo--;
                assaultRifleAmmoText.text = "AMMO: " + assaultRifleAmmo;
                Debug.Log(assaultRifleAmmo);
            }

            if (Time.time > fire && hasShotgunAmmo == true && isUsingShotgun == true && isLeft == true && Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Call the Shotgun use Left fucntion and then deduct a bullet
                //This adds a firerate to the Shotgun by only allowing it to fire when the timer resets essentially
                fire = Time.time + fireRateSG;
                SGUseLeft();
                shotgunAmmo--;
                shotgunAmmoText.text = "AMMO: " + shotgunAmmo;
                Debug.Log(shotgunAmmo);
            }
            if (Time.time > fire && hasShotgunAmmo == true && isUsingShotgun == true && isRight == true && Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Call the Shotgun use Right function and then deduct a bullet
                //This adds a firerate to the Shotgun by only allowing it to fire when the timer resets essentially
                fire = Time.time + fireRateSG;
                SGUseRight();
                shotgunAmmo--;
                shotgunAmmoText.text = "AMMO: " + shotgunAmmo;
                Debug.Log(shotgunAmmo);
            }

            if (Time.time > fire && rockets > 0 && isUsingRPG == true && isLeft == true && Input.GetKey(KeyCode.Mouse0))
            {
                fire = Time.time + fireRateRPG;
                RPGUseLeft();
                rockets--;
                rocketsText.text = "AMMO: " + rockets;
                Debug.Log(rockets);
            }

            if (Time.time > fire && rockets > 0  && isUsingRPG == true && isRight == true && Input.GetKey(KeyCode.Mouse0))
            {
                fire = Time.time + fireRateRPG;
                RPGUseRight();
                rockets--;
                rocketsText.text = "AMMO: " + rockets;
                Debug.Log(rockets);
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
                //If the random int is 3 then the easter egg animation will play
                anim.Play("IdleLeft");
                isLeft = true;
                isRight = false;
                int myRandom;
                myRandom = Random.Range(1, 3);
                if (myRandom == 1 || myRandom == 2)
                {
                    anim.Play("idleLeft");
                }
                if (myRandom == 3)
                {
                    anim.Play("idleLeftEE");
                }


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
                //If the random int is 3 then the easter egg animation will play
                anim.Play("IdleRight");
                isLeft = false;
                isRight = true;
                int myRandom;
                myRandom = Random.Range(1, 3);
                if (myRandom == 1 || myRandom == 2)
                {
                    anim.Play("idleRight");
                }
                if (myRandom == 3)
                {
                    anim.Play("idleRightEE");
                }
        }
            //Pressing H will holster the player's weapon
            if (Input.GetKey(KeyCode.H))
            {


                isUsingNoGun = true;
                isUsingHandgun = false;
                isUsingAssaultRifle = false;
                isUsingShotgun = false;
                isUsingRPG = false;
            }
            //Pressing 1 as long as they have the handgun, they will bring it out to use
            if (Input.GetKey(KeyCode.Alpha1))
            {
                if (hasHandgun == true)
                {
                    isUsingNoGun = false;
                    isUsingHandgun = true;
                    isUsingAssaultRifle = false;
                    isUsingShotgun = false;
                    isUsingRPG = false;
                    usingPistol();

                }
            }
        //Pressing 2 as long as they have the Assault Rifle, they will bring it out to use
        if (Input.GetKey(KeyCode.Alpha2))
            {
                if (hasAssaultRifle == true)
                {
                    isUsingNoGun = false;
                    isUsingHandgun = false;
                    isUsingAssaultRifle = true;
                    isUsingShotgun = false;
                    isUsingRPG = false;
                    usingAssaultRifle();

                }
            }
        //Pressing 3 as long as they have the Shotgun, they will bring it out to use
        if (Input.GetKey(KeyCode.Alpha3))
            {
                if (hasShotgun == true)
                {
                    isUsingNoGun = false;
                    isUsingHandgun = false;
                    isUsingAssaultRifle = false;
                    isUsingShotgun = true;
                    isUsingRPG = false;
                    usingShotgun();

                }
            }
        //Pressing 4 as long as they have the RPG, they will bring it out to use
        if (Input.GetKey(KeyCode.Alpha4))
            {
                if (hasRPG == true)
                {
                    isUsingNoGun = false;
                    isUsingHandgun = false;
                    isUsingAssaultRifle = false;
                    isUsingShotgun = false;
                    isUsingRPG = true;
                    usingRPG();
                }
            }

            //If the player is on the ground colliders and they press a jump button then they will jump
            if (Input.GetKeyDown(KeyCode.W) || (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.Space))))
            {

                if (isGrounded == true)
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.up * deanJump;
                }

            }
            //When the player turns call the usingAGun function to make sure the gun position changes
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

                RPGLeft.SetActive(false);
                RPGRight.SetActive(false);
                
                pistolAmmoText.GetComponent<Text>().enabled = false;
                shotgunAmmoText.GetComponent<Text>().enabled = false;
                assaultRifleAmmoText.GetComponent<Text>().enabled = false;

                weaponArea.SetActive(false);
                pistolPortrait.SetActive(false);
                shotgunPortrait.SetActive(false);
                AssaultRiflePortrait.SetActive(false);
                RPGPortrait.SetActive(false);

            }
        //If dean has no rockets then the version of his RPG with no rockets will display instead
        if (hasRockets == false && isRight == true && isUsingRPG == true)
        {
            RPGRightNoAmmo.SetActive(true);
            RPGLeftNoAmmo.SetActive(false);
            RPGLeft.SetActive(false);
            RPGRight.SetActive(false);
        }
        if (hasRockets == false && isLeft == true && isUsingRPG == true)
        {
            RPGRightNoAmmo.SetActive(false);
            RPGLeftNoAmmo.SetActive(true);
            RPGLeft.SetActive(false);
            RPGRight.SetActive(false);
        }

        
       
    }
       

    //For each using a gun function the gameobjects of each gun the player isn't using will be disabled
    //Meaning if the player is using a Shotgun then the RPG, Assault Rifle and Handgun wont be active
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

            RPGLeft.SetActive(false);
            RPGRight.SetActive(false);

            pistolAmmoText.GetComponent<Text>().enabled = false;
            shotgunAmmoText.GetComponent<Text>().enabled = false;
            assaultRifleAmmoText.GetComponent<Text>().enabled = false;
            rocketsText.GetComponent<Text>().enabled = false;

            weaponArea.SetActive(false);
            pistolPortrait.SetActive(false);
            shotgunPortrait.SetActive(false);
            AssaultRiflePortrait.SetActive(false);
            RPGPortrait.SetActive(false);

        }

        if (isUsingHandgun == true)
        {
            usingPistol();

            pistolAmmoText.GetComponent<Text>().enabled = true;
            shotgunAmmoText.GetComponent<Text>().enabled = false;
            assaultRifleAmmoText.GetComponent<Text>().enabled = false;
            rocketsText.GetComponent<Text>().enabled = false;

            weaponArea.SetActive(true);
            pistolPortrait.SetActive(true);
            shotgunPortrait.SetActive(false);
            AssaultRiflePortrait.SetActive(false);
            RPGPortrait.SetActive(false);
        }
        if (isUsingAssaultRifle == true)
        {
            usingAssaultRifle();

            pistolAmmoText.GetComponent<Text>().enabled = false;
            shotgunAmmoText.GetComponent<Text>().enabled = false;
            assaultRifleAmmoText.GetComponent<Text>().enabled = true;
            rocketsText.GetComponent<Text>().enabled = false;

            weaponArea.SetActive(true);
            pistolPortrait.SetActive(false);
            shotgunPortrait.SetActive(false);
            AssaultRiflePortrait.SetActive(true);
            RPGPortrait.SetActive(false);
        }
        if (isUsingShotgun == true)
        {
            usingShotgun();

            pistolAmmoText.GetComponent<Text>().enabled = false;
            shotgunAmmoText.GetComponent<Text>().enabled = true;
            assaultRifleAmmoText.GetComponent<Text>().enabled = false;
            rocketsText.GetComponent<Text>().enabled = false;

            weaponArea.SetActive(true);
            pistolPortrait.SetActive(false);
            shotgunPortrait.SetActive(true);
            AssaultRiflePortrait.SetActive(false);
            RPGPortrait.SetActive(false);
        }

        if (isUsingRPG == true)
        {
            usingRPG();

            pistolAmmoText.GetComponent<Text>().enabled = false;
            shotgunAmmoText.GetComponent<Text>().enabled = false;
            assaultRifleAmmoText.GetComponent<Text>().enabled = false;
            rocketsText.GetComponent<Text>().enabled = true;

            weaponArea.SetActive(true);
            pistolPortrait.SetActive(false);
            shotgunPortrait.SetActive(false);
            AssaultRiflePortrait.SetActive(false);
            RPGPortrait.SetActive(true);
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

            RPGLeft.SetActive(false);
            RPGRight.SetActive(false);
            RPGRightNoAmmo.SetActive(false);
            RPGLeftNoAmmo.SetActive(false);
        }
        if (isLeft == true)
        {

            pistolLeft.SetActive(true);
            pistolRight.SetActive(false);

            assaultRifleRight.SetActive(false);
            assaultRifleLeft.SetActive(false);

            shotgunLeft.SetActive(false);
            shotgunRight.SetActive(false);

            RPGLeft.SetActive(false);
            RPGRight.SetActive(false);
            RPGRightNoAmmo.SetActive(false);
            RPGLeftNoAmmo.SetActive(false);

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

            RPGLeft.SetActive(false);
            RPGRight.SetActive(false);
            RPGRightNoAmmo.SetActive(false);
            RPGLeftNoAmmo.SetActive(false);



        }
        if (isLeft == true)
        {

            pistolLeft.SetActive(false);
            pistolRight.SetActive(false);

            assaultRifleRight.SetActive(false);
            assaultRifleLeft.SetActive(false);

            shotgunLeft.SetActive(true);
            shotgunRight.SetActive(false);

            RPGLeft.SetActive(false);
            RPGRight.SetActive(false);
            RPGRightNoAmmo.SetActive(false);
            RPGLeftNoAmmo.SetActive(false);



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

            RPGLeft.SetActive(false);
            RPGRight.SetActive(false);
            RPGRightNoAmmo.SetActive(false);
            RPGLeftNoAmmo.SetActive(false);


        }
        if (isLeft == true)
        {

            pistolLeft.SetActive(false);
            pistolRight.SetActive(false);

            assaultRifleRight.SetActive(false);
            assaultRifleLeft.SetActive(true);

            shotgunLeft.SetActive(false);
            shotgunRight.SetActive(false);

            RPGLeft.SetActive(false);
            RPGRight.SetActive(false);
            RPGRightNoAmmo.SetActive(false);
            RPGLeftNoAmmo.SetActive(false);

        }
    }

    public void usingRPG()
    {
        if (isRight == true)
        {
            pistolLeft.SetActive(false);
            pistolRight.SetActive(false);

            assaultRifleRight.SetActive(false);
            assaultRifleLeft.SetActive(false);

            shotgunLeft.SetActive(false);
            shotgunRight.SetActive(false);

            RPGLeft.SetActive(false);
            RPGRight.SetActive(true);
            RPGRightNoAmmo.SetActive(false);
            RPGLeftNoAmmo.SetActive(false);
        }

        if (isLeft == true)
        {
            pistolLeft.SetActive(false);
            pistolRight.SetActive(false);

            assaultRifleRight.SetActive(false);
            assaultRifleLeft.SetActive(false);

            shotgunLeft.SetActive(false);
            shotgunRight.SetActive(false);

            RPGLeft.SetActive(true);
            RPGRight.SetActive(false);
            RPGRightNoAmmo.SetActive(false);
            RPGLeftNoAmmo.SetActive(false);
        }
    }
    //Finds the game object of the plasma location
    //Finds the shooting script and makes Dean fire in the way he is facing
    public void pistolUseRight()
    {
        GameObject PLR = GameObject.Find("plasmaLocationRight");
        ShootingScript shootScript = PLR.GetComponent<ShootingScript>();
        shootScript.shootRight();
        AudioSource.PlayClipAtPoint(pistolShot, Camera.main.transform.position);
    }

    public void pistolUseLeft()
    {
        GameObject PLL = GameObject.Find("plasmaLocationLeft");
        ShootingScript shootScript = PLL.GetComponent<ShootingScript>();
        shootScript.shootLeft();
        AudioSource.PlayClipAtPoint(pistolShot, Camera.main.transform.position);
    }

    public void ARUseLeft()
    {   
        GameObject ARPLL = GameObject.Find("arPlasmaLocationLeft");
        ShootingScript shootScript = ARPLL.GetComponent<ShootingScript>();
        shootScript.ARShootLeft();
        AudioSource.PlayClipAtPoint(ARShot, Camera.main.transform.position);
    }

    public void ARUseRight()
    {
        GameObject ARPLR = GameObject.Find("arPlasmaLocationRight");
        ShootingScript shootScript = ARPLR.GetComponent<ShootingScript>();
        shootScript.ARShootRight();
        AudioSource.PlayClipAtPoint(ARShot, Camera.main.transform.position);
    }

    public void SGUseLeft()
    {
        
        GameObject PLL = GameObject.Find("sgPlasmaLocationLeft");
        ShootingScript shootScript = PLL.GetComponent<ShootingScript>();
        shootScript.ShotgunShootLeft();
        AudioSource.PlayClipAtPoint(ShotgunShot, Camera.main.transform.position);
    }

    public void SGUseRight()
    {
        
        GameObject PLL = GameObject.Find("sgPlasmaLocationRight");
        ShootingScript shootScript = PLL.GetComponent<ShootingScript>();
        shootScript.ShotgunShootRight();
        AudioSource.PlayClipAtPoint(ShotgunShot, Camera.main.transform.position);
    }

    public void RPGUseLeft()
    {
        GameObject RLL = GameObject.Find("RLLocation");
        ShootingScript shootScript = RLL.GetComponent<ShootingScript>();
        shootScript.RPGShootLeft();
        //Dean is thrown back a bit when he fires the RPG
        deanAnderson.GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
        AudioSource.PlayClipAtPoint(RPGShot, Camera.main.transform.position);

    }

    public void RPGUseRight()
    {
        GameObject RRL = GameObject.Find("RRLocation");
        ShootingScript shootScript = RRL.GetComponent<ShootingScript>();
        shootScript.RPGShootRight();
        //Dean is thrown back a bit when he fires the RPG
        deanAnderson.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
        AudioSource.PlayClipAtPoint(RPGShot, Camera.main.transform.position);
    }

    //Adding to the score
    //For each function here the score will increase and then the onscreen score counter will increase
    public void increaseScoreCollectible()
    {
        score += 500;
        scoreText.text = "Score: " + score;
    }
    public void increaseScoreMummy()
    {
        score += 50;
        scoreText.text = "Score: " + score;
    }
    public void increaseScorePharoah()
    {
        score += 100;
        scoreText.text = "Score: " + score;
    }
    public void increaseScoreKnight1()
    {
        score += 150;
        scoreText.text = "Score: " + score;
    }
    public void increaseScoreKnight2()
    {
        score += 200;
        scoreText.text = "Score: " + score;
    }
    public void increaseScoreRoman1()
    {
        score += 250;
        scoreText.text = "Score: " + score;
    }
    public void increaseScoreRoman2()
    {
        score += 300;
        scoreText.text = "Score: " + score;
    }
    public void increaseScoreRobot()
    {
        score += 400;
        scoreText.text = "Score: " + score;
    }

    //For Exiting Levels and jumping


    public void OnCollisionEnter2D(Collision2D collision)
    {
        //If Dean is on a collider called jumpCollider then he can jump
        //If not then he isn't grounded
        if (collision.gameObject.tag == "jumpCollider")
        {
            Debug.Log("Jump True");
            isGrounded = true;
        }
        //If Dean is hit by an enemy or enemy projectile then he will lose health and be knocked back
        //A sound of Dean being hurt will also play
        if (collision.gameObject.tag == "Mummy" && isLeft)
        {
            deanAnderson.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 5);
            currentHealth -= 10;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(Hurt, Camera.main.transform.position);
        }

        if (collision.gameObject.tag == "Mummy" && isRight)
        {
            deanAnderson.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, -5);
            currentHealth -= 10;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(Hurt, Camera.main.transform.position);
        }

        if (collision.gameObject.tag == "Pharoah" && isLeft)
        {
            deanAnderson.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 5);
            currentHealth -= 20;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(Hurt, Camera.main.transform.position);
        }

        if (collision.gameObject.tag == "Pharoah" && isRight)
        {
            deanAnderson.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, -5);
            currentHealth -= 20;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(Hurt, Camera.main.transform.position);
        }

        if (collision.gameObject.tag == "Knight1" && isLeft)
        {
            deanAnderson.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 5);
            currentHealth -= 25;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(Hurt, Camera.main.transform.position);
        }

        if (collision.gameObject.tag == "Knight1" && isRight)
        {
            deanAnderson.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, -5);
            currentHealth -= 25;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(Hurt, Camera.main.transform.position);
        }
        if (collision.gameObject.tag == "Knight2" && isLeft)
        {
            deanAnderson.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 5);
            currentHealth -= 25;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(Hurt, Camera.main.transform.position);
        }

        if (collision.gameObject.tag == "Knight2" && isRight)
        {
            deanAnderson.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, -5);
            currentHealth -= 25;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(Hurt, Camera.main.transform.position);
        }
        if (collision.gameObject.tag == "Roman1" && isLeft)
        {
            deanAnderson.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 5);
            currentHealth -= 25;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(Hurt, Camera.main.transform.position);
        }

        if (collision.gameObject.tag == "Roman1" && isRight)
        {
            deanAnderson.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, -5);
            currentHealth -= 25;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(Hurt, Camera.main.transform.position);
        }
        if (collision.gameObject.tag == "Robot" && isLeft)
        {
            deanAnderson.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 5);
            currentHealth -= 35;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(Hurt, Camera.main.transform.position);
        }

        if (collision.gameObject.tag == "Robot" && isRight)
        {
            deanAnderson.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, -5);
            currentHealth -= 35;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(Hurt, Camera.main.transform.position);
        }
    }

 

    public void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "playerDeathZone")
        {
            //kill the player if they fall down a pit
            currentHealth = minHealth;
            healthSlider.value = currentHealth;
            //Calls the player death function
            PlayerDeath();
        }

        //if the player is hit by a spear, throw them back and take 25 health off
        if (collision.gameObject.tag == "enemySpear" && isLeft)
        {
            deanAnderson.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 5);
            currentHealth -= 25;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(Hurt, Camera.main.transform.position);
        }
        if (collision.gameObject.tag == "enemySpear" && isRight)
        {
            deanAnderson.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, -5);
            currentHealth -= 25;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(Hurt, Camera.main.transform.position);
        }
        //If the player is hit by a plasma round then take health off..
        if (collision.gameObject.tag == "plasmaEnemy")
        {
           
            currentHealth -= 15;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(Hurt, Camera.main.transform.position);
        }
      

        //Obtaining the active scene
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (collision.gameObject.tag == "playerExit")
        {

            //Saving the player's ammo and score after each level
            PlayerPrefs.SetInt("scoreText", score);
            PlayerPrefs.SetInt("pistolAmmoText", pistolAmmo);
            PlayerPrefs.SetInt("shotgunAmmoText", shotgunAmmo);
            PlayerPrefs.SetInt("assaultRifleAmmoText", assaultRifleAmmo);
            PlayerPrefs.SetInt("rocketsText", rockets);
            PlayerPrefs.Save();

            if (sceneName == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            if (sceneName == "Level2")
            {
                SceneManager.LoadScene("Level3");
            }
            if (sceneName == "Level3")
            {
                SceneManager.LoadScene("Level4");
            }
        }
        //picking up the shotgun from the ground
        if (collision.gameObject.tag == "ShotgunPickup")
        {
            hasShotgun = true;
        }

        //picking up the assault rifle from the ground
        if (collision.gameObject.tag == "AssaultRiflePickup")
        {
            hasAssaultRifle = true;
        }
        //Picking up RPG
        if (collision.gameObject.tag == "RPGPickup")
        {
            hasRPG = true;
            AudioSource.PlayClipAtPoint(RPGLaugh, Camera.main.transform.position);
        }

        //Ammo is obtained from boxes on the ground but only if they have the weapon
        //This is for balance reasons
        //A sound of collecting ammo is also played
        if (collision.gameObject.tag == "ammo")
        {
            AudioSource.PlayClipAtPoint(ammo, Camera.main.transform.position);
            pistolAmmo += 20;
            pistolAmmoText.text = "AMMO: " + pistolAmmo;
            if (hasAssaultRifle == true)
            {
                assaultRifleAmmo += 40;
                assaultRifleAmmoText.text = "AMMO: " + assaultRifleAmmo;
            }
            if (hasShotgun == true)
            {
                shotgunAmmo += 10;
                shotgunAmmoText.text = "AMMO: " + shotgunAmmo;
            }
            if (hasRPG == true)
            {
                rockets += 3;
                rocketsText.text = "AMMO: " + rockets;
            }
        }
        //If the player picks up a health pack then their health will increase by 50
        if (collision.gameObject.tag == "Health")
        {
            //Also plays a sound of eating when picking up the health kit
            currentHealth += 50;
            healthSlider.value = currentHealth;
            AudioSource.PlayClipAtPoint(health, Camera.main.transform.position);
            //If their current health is at the current maximum health then it will not increase anymore
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
                healthSlider.value = currentHealth;
                
            }
        }
        //If the player walks over a coin then their score will increase
        if (collision.gameObject.tag == "Collectible1")
        {
            increaseScoreCollectible();
        }
    }
    //whilst the player is on a platform they will move with it if it can move that is
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "jumpCollider")
        {
            deanAnderson.transform.SetParent(collision.transform);
            
            //transform.parent = collision.transform;
            isGrounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "jumpCollider")
        {
            Debug.Log("Jump false");
            isGrounded = false;
        }
        if (collision.gameObject.tag == "jumpCollider")
        {
            transform.parent = null;
        }
    }

}