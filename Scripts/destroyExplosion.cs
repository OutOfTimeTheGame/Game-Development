using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyExplosion : MonoBehaviour {
    //Kieran Lewis 2018 :)
    public GameObject explosion;
    public AudioClip RPGExplosion;

	// Use this for initialization
	void Start ()
    {
        Destroy(explosion, 0.4f);
        AudioSource.PlayClipAtPoint(RPGExplosion, Camera.main.transform.position);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
