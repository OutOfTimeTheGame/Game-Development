
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
    //Kieran Lewis 2018 :) 
{
    //Player weapon ammo
    public GameObject pistolPlasmaLeft;
    public GameObject pistolPlasmaRight;

    public GameObject ARPlasmaLeft;
    public GameObject ARPlasmaRight;

    public GameObject ShotgunPlasmaLeft;
    public GameObject ShotgunPlasmaRight;

    public GameObject RPGShotRight;
    public GameObject RPGShotLeft;
    public GameObject RPGBackdraftRight;
    public GameObject RPGBackdraftLeft;
    public GameObject RPGExplosionRight;
    public GameObject RPGExplosionLeft;

    //Enemy weapon ammo
    public GameObject SpearLeft;
    public GameObject SpearRight;

    public void shootRight()
    {
        GameObject plasmaR;
        plasmaR = Instantiate(pistolPlasmaRight, transform.position, Quaternion.identity);
        Destroy(plasmaR, 3f);
    }

    public void shootLeft()
    {
        GameObject plasmaL;
        plasmaL = Instantiate(pistolPlasmaLeft, transform.position, Quaternion.identity);
        Destroy(plasmaL, 3f);
    }

    public void ARShootLeft()
    {
        GameObject ARplasmaL;
        ARplasmaL = Instantiate(ARPlasmaLeft, transform.position, Quaternion.identity);
        Destroy(ARplasmaL, 4f);
    }

    public void ARShootRight()
    {
        GameObject ARplasmaR;
        ARplasmaR = Instantiate(ARPlasmaRight, transform.position, Quaternion.identity);
        Destroy(ARplasmaR, 4f);
    }

    public void ShotgunShootLeft()
    {
        GameObject SGplasmaL;
        SGplasmaL = Instantiate(ShotgunPlasmaLeft, transform.position, Quaternion.identity);
        Destroy(SGplasmaL, 2.5f);
    }

    public void ShotgunShootRight()
    {
        GameObject SGplasmaR;
        SGplasmaR = Instantiate(ShotgunPlasmaRight, transform.position, Quaternion.identity);
        Destroy(SGplasmaR, 2.5f);
    }

    public void RPGShootLeft()
    {
        //Start the backdraft
        // Instantiate(RPGBackdraftLeft, transform.position, Quaternion.identity);
        // Destroy(RPGBackdraftLeft, 1.5f);
        //Fire the rocket
        GameObject RPGRoundL;
        RPGRoundL = Instantiate(RPGShotLeft, transform.position, Quaternion.identity);



    }

    public void RPGShootRight()
    {
        //Start the backdraft
        //Instantiate(RPGBackdraftRight, transform.position, Quaternion.identity);
        //Destroy(RPGBackdraftRight, 1.5f);
        //Fire the rocket
        GameObject RPGRoundR;
        RPGRoundR = Instantiate(RPGShotRight, transform.position, Quaternion.identity);


    }


    //These two functions handle the spear throwing by the enemies
    public void enemySpearLeft()
    {
        GameObject SL;
        SL = Instantiate(SpearLeft, transform.position, Quaternion.identity);
        Destroy(SpearLeft, 3.5f);
    }

    public void enemySpearRight()
    {
        GameObject SR;
        SR = Instantiate(SpearRight, transform.position, Quaternion.identity);
        Destroy(SpearLeft, 3.5f);
    }
}