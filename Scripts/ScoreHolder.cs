using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHolder : MonoBehaviour {

    public int score;


    //The Player's Score text which will be displayed on the screen
    public Text scoreText;

    public GameObject deanScore;

    // Use this for initialization
    void Start()
    {

    }

    private void Awake()
    {
        DontDestroyOnLoad(deanScore);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
