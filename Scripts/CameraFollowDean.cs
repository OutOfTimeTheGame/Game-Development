using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowDean : MonoBehaviour {

    //our player reference
    public GameObject deanAnderson;
    //The speed that the camera will move
    private float cameraMoveSpeed = 1.25f;

    //This script is from https://kylewbanks.com/blog/unity-make-camera-follow-player-smoothly-and-fluidly
    //Its use is for allowing the camera to follow the player on each axis
    //I do not take any credit for this script whatsoever however the GameObject Dean is my GameObject nothing else is in the script

    // Update is called once per frame
    void Update()
    {

        float interpolation = cameraMoveSpeed * Time.deltaTime;

        Vector3 position = this.transform.position;

        position.x = Mathf.Lerp(this.transform.position.x, deanAnderson.transform.position.x, interpolation);
        position.y = Mathf.Lerp(this.transform.position.y, deanAnderson.transform.position.y, interpolation);

        this.transform.position = position;

    }
}
