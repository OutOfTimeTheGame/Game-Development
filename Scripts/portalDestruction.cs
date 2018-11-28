using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalDestruction : MonoBehaviour {
    //Kieran Lewis 2018 :)
    public GameObject portal;


	// Use this for initialization
	void Start ()
    {
        //The portal will destroy its self when the player enters the level
        Destroy(portal, 1.5f);
	}
}
