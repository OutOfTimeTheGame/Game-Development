using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyThrowSpear : MonoBehaviour
{
    //Kieran Lewis 2018 :)
    public GameObject SpearLeft;
    public float fireRateSpear = 0.8f;
    public float fire = 0.0f;
   
    private void OnTriggerStay2D(Collider2D collision)
    {
        pharoahMove ph = GetComponentInParent<pharoahMove>();
        if (collision.gameObject.tag == "Dean" && Time.time > fire && ph.pharoahMovingLeft == true)
        {
            fire = Time.time + fireRateSpear;
            
            ShootingScript shootScript = GetComponent<ShootingScript>();
            shootScript.enemySpearLeft();           
        }
    }
 
}
