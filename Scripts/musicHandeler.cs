using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class musicHandeler : MonoBehaviour {
    
    public AudioClip BGM;
    
    void Awake()
    {

        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        //Plays the background music in front of the camera
        AudioSource.PlayClipAtPoint(BGM, Camera.main.transform.position);   
    }
}
