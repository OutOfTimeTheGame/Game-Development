using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{
    //Kieran Lewis 2018 :)
    public float platformMoveSpeed = 1.6f;
    public bool movingLeft;
    public bool movingRight;

    // Use this for initialization
    void Start()
    {
        movingLeft = true;
        movingRight = false;
    }



    // Update is called once per frame
    void Update()
    {
        if (movingLeft == true)
        {
            transform.Translate(new Vector2(-platformMoveSpeed, 0) * Time.deltaTime * platformMoveSpeed);
        }
        if (movingRight == true)
        {
            transform.Translate(new Vector2(+platformMoveSpeed, 0) * Time.deltaTime * platformMoveSpeed);
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "zoneLeft")
        {
            movingLeft = false;
            movingRight = true;
        }

        if (collision.gameObject.tag == "zoneRight")
        {
            movingLeft = true;
            movingRight = false;
        }
    }
}

