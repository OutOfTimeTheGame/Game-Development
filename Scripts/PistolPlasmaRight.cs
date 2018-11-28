using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolPlasmaRight : MonoBehaviour
{
    //Kieran Lewis 2018 :)
    public float plasmaSpeed = 8.0f;
    public Rigidbody2D rb2;

    public GameObject pistolPlasmaLeft;
    public GameObject pistolPlasmaRight;

    public GameObject ARPlasmaLeft;
    public GameObject ARPlasmaRight;

    public GameObject ShotgunPlasmaLeft;
    public GameObject ShotgunPlasmaRight;

    public GameObject enemyPlasmaLeft;
    public GameObject enemyPlasmaRight;

    // Use this for initialization
    void Start ()
    {
        rb2 = GetComponent<Rigidbody2D>();

        rb2.velocity = transform.right * plasmaSpeed;
    }
	
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mummy")
        {
            Destroy(pistolPlasmaLeft);
            Destroy(pistolPlasmaRight);
            Destroy(ARPlasmaLeft);
            Destroy(ARPlasmaRight);
            Destroy(ShotgunPlasmaLeft);
            Destroy(ShotgunPlasmaRight);
        }

        if (collision.gameObject.tag == "Pharoah")
        {
            Destroy(pistolPlasmaLeft);
            Destroy(pistolPlasmaRight);
            Destroy(ARPlasmaLeft);
            Destroy(ARPlasmaRight);
            Destroy(ShotgunPlasmaLeft);
            Destroy(ShotgunPlasmaRight);
        }

        if (collision.gameObject.tag == "Knight1")
        {
            Destroy(pistolPlasmaLeft);
            Destroy(pistolPlasmaRight);
            Destroy(ARPlasmaLeft);
            Destroy(ARPlasmaRight);
            Destroy(ShotgunPlasmaLeft);
            Destroy(ShotgunPlasmaRight);
        }

        if (collision.gameObject.tag == "Knight2")
        {
            Destroy(pistolPlasmaLeft);
            Destroy(pistolPlasmaRight);
            Destroy(ARPlasmaLeft);
            Destroy(ARPlasmaRight);
            Destroy(ShotgunPlasmaLeft);
            Destroy(ShotgunPlasmaRight);
        }

        if (collision.gameObject.tag == "Roman1")
        {
            Destroy(pistolPlasmaLeft);
            Destroy(pistolPlasmaRight);
            Destroy(ARPlasmaLeft);
            Destroy(ARPlasmaRight);
            Destroy(ShotgunPlasmaLeft);
            Destroy(ShotgunPlasmaRight);
        }

        if (collision.gameObject.tag == "Roman2")
        {
            Destroy(pistolPlasmaLeft);
            Destroy(pistolPlasmaRight);
            Destroy(ARPlasmaLeft);
            Destroy(ARPlasmaRight);
            Destroy(ShotgunPlasmaLeft);
            Destroy(ShotgunPlasmaRight);
        }

        if (collision.gameObject.tag == "Robot")
        {
            Destroy(pistolPlasmaLeft);
            Destroy(pistolPlasmaRight);
            Destroy(ARPlasmaLeft);
            Destroy(ARPlasmaRight);
            Destroy(ShotgunPlasmaLeft);
            Destroy(ShotgunPlasmaRight);
        }

        if (collision.gameObject.tag == "Dean")
        {
            Destroy(enemyPlasmaRight);
        }

    }
}
