using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotShootRight : MonoBehaviour
{
    //Kieran Lewis 2018 :)
    public GameObject plasmaRight;
    public float fireRatePlasma = 0.2f;
    public float fire = 0.0f;
    public AudioClip ARShot;

    private void OnTriggerStay2D(Collider2D collision)
    {
        robotMove rm = GetComponentInParent<robotMove>();
        if (collision.gameObject.tag == "Dean" && Time.time > fire && rm.isRight == true)
        {
            fire = Time.time + fireRatePlasma;

            ShootingScript shootScript = GetComponent<ShootingScript>();
            shootScript.ARShootRight();
            AudioSource.PlayClipAtPoint(ARShot, Camera.main.transform.position);
        }
    }
}
