using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateScript : MonoBehaviour
{

    //Kieran Lewis 2018 :) 

    public GameObject briefcase;

    public float rotSpeed = 1.2f;
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Time.deltaTime, rotSpeed, 0);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dean")
        {
            Destroy(briefcase, 0.1f);
        }
    }
}
