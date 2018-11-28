using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyThrowSpearRight : MonoBehaviour
{
    //Kieran Lewis 2018 :)
    public GameObject SpearRight;
    public float fireRateSpear = 0.8f;
    public float fire = 0.0f;
    

    private void OnTriggerStay2D(Collider2D collision)
    {
        //First we call the parent's script
        pharoahMove ph = GetComponentInParent<pharoahMove>();
        //if the collider is touching dean and the time is greater than last fired. Now if the pharoah is moving right from the parent script then
        if (collision.gameObject.tag == "Dean" && Time.time > fire && ph.pharoahMovingRight == true)
        {
            //the fire float is now time + the firerate of the spear
            fire = Time.time + fireRateSpear;
            //call the shooting script and make the pharoah throw the spear
            ShootingScript shootScript = GetComponent<ShootingScript>();
            shootScript.enemySpearRight();
        }
    }
   
}
