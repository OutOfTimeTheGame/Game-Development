using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketShootRight : MonoBehaviour {
    //Kieran Lewis 2018 :)
    public GameObject RocketLeft;
    public GameObject RocketRight;

    public GameObject Explosion;
    public AudioClip RPGExplosion;

    public float rocketSpeed = 8.0f;
    public Rigidbody2D rb2;
    // Use this for initialization
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        rb2.velocity = transform.right * rocketSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the rocket collides with an enemy or the jump collider then it will explode and play a sound
        if (collision.gameObject.tag == "Mummy" || collision.gameObject.tag == "Pharoah" || collision.gameObject.tag == "Knight1" || collision.gameObject.tag == "Knight2")
        {   
            Destroy(RocketRight);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(RPGExplosion, Camera.main.transform.position);
        }

        if (collision.gameObject.tag == "Roman1" || collision.gameObject.tag == "Roman2" || collision.gameObject.tag == "Robot" || collision.gameObject.tag == "jumpCollider")
        {
            Destroy(RocketRight);
            Instantiate(Explosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(RPGExplosion, Camera.main.transform.position);
        }
    }
}