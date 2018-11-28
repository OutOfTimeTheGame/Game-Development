using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPickup : MonoBehaviour {
    //Kieran Lewis 2018 :)
    public GameObject pickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Dean")
        {
            Destroy(pickup);
        }
    }
}
