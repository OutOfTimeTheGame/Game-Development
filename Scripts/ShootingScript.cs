
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
    //Kieran Lewis 2018 :) 
{

    public GameObject pistolPlasmaLeft;
    public GameObject pistolPlasmaRight;

    public GameObject ARPlasmaLeft;
    public GameObject ARPlasmaRight;

    public GameObject ShotgunPlasmaLeft;
    public GameObject ShotgunPlasmaRight;


    void Start()
    {

    }
    void Update()
    {

    }

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


    
}