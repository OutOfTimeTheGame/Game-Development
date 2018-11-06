using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpScript : MonoBehaviour {
    //This script is not my own work it is from a youtuber called Board To Bits Games
    //https://www.youtube.com/watch?v=7KiK0Aqtmzc
    //This is were I found the code for the script
    //It's purpose is to make Deans's jumping feel more realistic and less moon like
    // Use this for initialization
    public float deanFallMultiplier = 2.00f;
    public float deanLowJumpMultiplier = 1.75f;

    Rigidbody2D deanA;

    private void Awake()
    {
        deanA = GetComponent<Rigidbody2D>();
    }

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (deanA.velocity.y < 0)
        {
            deanA.velocity += Vector2.up * Physics2D.gravity.y * (deanFallMultiplier - 1) * Time.deltaTime;
        }

        else if (deanA.velocity.y > 0 && !Input.GetKey(KeyCode.W))
        {
            deanA.velocity += Vector2.up * Physics2D.gravity.y * (deanLowJumpMultiplier - 1) * Time.deltaTime;
        }

        else if (deanA.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            deanA.velocity += Vector2.up * Physics2D.gravity.y * (deanLowJumpMultiplier - 1) * Time.deltaTime;
        }


    }
}
