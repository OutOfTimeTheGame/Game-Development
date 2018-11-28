using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spearRight : MonoBehaviour {
    //Kieran Lewis 2018 :)
    public GameObject SpearRight;
    Rigidbody2D rb2;
    public float spearSpeed = 6.00f;

    // Use this for initialization
    void Start()
    {

        rb2 = GetComponent<Rigidbody2D>();

        rb2.velocity = transform.right * spearSpeed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dean")
        {
            Destroy(SpearRight);
        }
    }
}
