using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalDestruction : MonoBehaviour {

    public GameObject portal;


	// Use this for initialization
	void Start ()
    {
        Destroy(portal, 1.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
