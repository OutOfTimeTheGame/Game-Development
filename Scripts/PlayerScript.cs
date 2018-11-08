using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{


//Kieran Lewis 2018 :) 


    public GameObject deanAnderson;

    public float deanSpeed = 1.5f;
    public float deanJump = 5.0f;

    public int pistolAmmo;
    public int shotgunAmmo;
    public int assaultRifleAmmo;

    public Text pistolAmmoText;
    public Text shotgunAmmoText;
    public Text assaultRifleAmmoText;

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

    public GameObject weaponArea;
    public GameObject pistolPortrait;
    public GameObject shotgunPortrait;
    public GameObject AssaultRiflePortrait;

    //Assault Rifle Firerate
    public float fireRateAR = 0.18f;
    public float fire = 0.0f;
    //Shotgun Firerate
    public float fireRateSG = 0.60f;


    //Health
    public int maxHealth;
    public int minHealth;
    public int currentHealth;

    public Slider healthSlider;





    // Use this for initialization
    void Start()
    {
        //obtaining the current scene
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

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

        pistolAmmo += 20;
        shotgunAmmo += 10;
        assaultRifleAmmo += 40;

        hasPistolAmmo = true;
        hasShotgunAmmo = true;
        hasAssaultRifle = true;


        //Preparing the ammo HUD
        //create a reference to the text of each ammo
        pistolAmmoText.text = "AMMO: " + pistolAmmo;
        shotgunAmmoText.text = "AMMO: " + shotgunAmmo;
        assaultRifleAmmoText.text = "AMMO: " + assaultRifleAmmo;
        //Hide all of the ammo counters on startup
        pistolAmmoText.GetComponent<Text>().enabled = false;
        shotgunAmmoText.GetComponent<Text>().enabled = false;
        assaultRifleAmmoText.GetComponent<Text>().enabled = false;
        weaponArea.SetActive(false);
        pistolPortrait.SetActive(false);
        shotgunPortrait.SetActive(false);
        AssaultRiflePortrait.SetActive(false);

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
        }

        if (sceneName == "Level3")
        {
            maxHealth = 150;
            minHealth = 0;
            currentHealth = maxHealth;
        }

        if (sceneName == "Level4")
        {
            maxHealth = 200;
            minHealth = 0;
            currentHealth = maxHealth;
        }

        healthSlider.value = currentHealth;

    }

    public void enemyDamage()
    {
        currentHealth -= 10;
        healthSlider.value = currentHealth;
    }


    public void idleLeft()
    {
        anim.SetBool("hasStoppedLeft", true);
    }

    public void idleRight()
    {
        anim.SetBool("hasStoppedRight", true);
    }

    public void PlayerDeath()
    {
        Destroy(deanAnderson, 0.25f);
    }

    void Update()
    {

        //enemyDamage();

        if (Input.GetKey(KeyCode.Q))
        {
            currentHealth--;
            healthSlider.value = currentHealth;
            if (currentHealth <= minHealth)
            {
                currentHealth = minHealth;
            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            currentHealth++;
            healthSlider.value = currentHealth;
            if (currentHealth >= maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

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
        if(shotgunAmmo >0)
        {
            hasShotgunAmmo = true;
        }
        else
        {
            hasShotgunAmmo = false;
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
            //Call the Shotgun use Right fucntion and then deduct a bullet
            //This adds a firerate to the Shotgun by only allowing it to fire when the timer resets essentially
            fire = Time.time + fireRateSG;
            SGUseRight();
            shotgunAmmo--;
            shotgunAmmoText.text = "AMMO: " + shotgunAmmo;
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

            pistolAmmoText.GetComponent<Text>().enabled = false;
            shotgunAmmoText.GetComponent<Text>().enabled = false;
            assaultRifleAmmoText.GetComponent<Text>().enabled = false;

            weaponArea.SetActive(false);
            pistolPortrait.SetActive(false);
            shotgunPortrait.SetActive(false);
            AssaultRiflePortrait.SetActive(false);

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

            pistolAmmoText.GetComponent<Text>().enabled = false;
            shotgunAmmoText.GetComponent<Text>().enabled = false;
            assaultRifleAmmoText.GetComponent<Text>().enabled = false;

            weaponArea.SetActive(false);
            pistolPortrait.SetActive(false);
            shotgunPortrait.SetActive(false);
            AssaultRiflePortrait.SetActive(false);

        }

        if (isUsingHandgun == true)
        {
            usingPistol();

            pistolAmmoText.GetComponent<Text>().enabled = true;
            shotgunAmmoText.GetComponent<Text>().enabled = false;
            assaultRifleAmmoText.GetComponent<Text>().enabled = false;

            weaponArea.SetActive(true);
            pistolPortrait.SetActive(true);
            shotgunPortrait.SetActive(false);
            AssaultRiflePortrait.SetActive(false);
        }
        if (isUsingAssaultRifle == true)
        {
            usingAssaultRifle();

            pistolAmmoText.GetComponent<Text>().enabled = false;
            shotgunAmmoText.GetComponent<Text>().enabled = false;
            assaultRifleAmmoText.GetComponent<Text>().enabled = true;


            weaponArea.SetActive(true);
            pistolPortrait.SetActive(false);
            shotgunPortrait.SetActive(false);
            AssaultRiflePortrait.SetActive(true);
        }
        if (isUsingShotgun == true)
        {
            usingShotgun();

            pistolAmmoText.GetComponent<Text>().enabled = false;
            shotgunAmmoText.GetComponent<Text>().enabled = true;
            assaultRifleAmmoText.GetComponent<Text>().enabled = false;

            weaponArea.SetActive(true);
            pistolPortrait.SetActive(false);
            shotgunPortrait.SetActive(true);
            AssaultRiflePortrait.SetActive(false);
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
        
        GameObject ARPLL = GameObject.Find("arPlasmaLocationLeft");
        ShootingScript shootScript = ARPLL.GetComponent<ShootingScript>();
        shootScript.ARShootLeft();
    }

    public void ARUseRight()
    {
        GameObject ARPLR = GameObject.Find("arPlasmaLocationRight");
        ShootingScript shootScript = ARPLR.GetComponent<ShootingScript>();
        shootScript.ARShootRight();
    }

    public void SGUseLeft()
    {
        
        GameObject PLL = GameObject.Find("sgPlasmaLocationLeft");
        ShootingScript shootScript = PLL.GetComponent<ShootingScript>();
        shootScript.ShotgunShootLeft();
    }

    public void SGUseRight()
    {
        
        GameObject PLL = GameObject.Find("sgPlasmaLocationRight");
        ShootingScript shootScript = PLL.GetComponent<ShootingScript>();
        shootScript.ShotgunShootRight();
    }

    //For Exiting Levels and jumping
   

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "jumpCollider")
        {
            Debug.Log("Jump True");
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

    public void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "playerDeathZone")
        {
            //kill the player if they fall down a pit
            currentHealth = minHealth;
            healthSlider.value = currentHealth;
            PlayerDeath();
        }

        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (collision.gameObject.tag == "playerExit")
        {
            if (sceneName == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }

        }
    }
    //whilst the player is on a platform they will move with it if it can move that is
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "jumpCollider")
        {
            transform.parent = collision.transform;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "jumpCollider")
        {
            Debug.Log("Jump false");
            isGrounded = false;
        }
    }




}
