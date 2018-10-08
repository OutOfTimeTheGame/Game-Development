using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSelection : MonoBehaviour
    //Kieran Lewis 2018 :) 
{

	// Use this for initialization
	void Start ()
    {
        //This is for the pause function of the game, the time scale will be set to 0 when the player presses pause
        Time.timeScale = 1f;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Debug Cheats
        //Pressing 1 loads level 1, 2 loads level 2, 3 loads level 3 and 4 loads level 4
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("starting level 1");
            Level1();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("starting level 2");
            Level2();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("starting level 3");
            Level3();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("starting level 4");
            Level4();
        }
    }

    public void Play()
    {
        //When New Game is pressed then the first level will load.
        Debug.Log("Level 1 has loaded efficiently");
        Application.LoadLevel("Level1");
    }

    public void Help()
    {
        //When the help button is pressed then the help menu will show
        Debug.Log("Help Menu has loaded");
        Application.LoadLevel("Help");
    }

    public void Quit()
    {
        //The game will quit when the quit button has been pressed
        Application.Quit();
    }

    public void mainMenu()
    {
        Debug.Log("Main Menu has loaded");
        Application.LoadLevel("MainMenu");
    }

    public void restartLevel()
    {
        Debug.Log("Level will be restarted");
        Application.LoadLevel(Application.loadedLevel);
    }

    //Debug Levels
    //This will be removed in the final release but will be available in the prototype
    public void Level1()
    {
        Debug.Log("I've loaded Level 1 :)"); 
        Application.LoadLevel("Level1");
    }

    public void Level2()
    {
        Debug.Log("I've loaded Level 2 :)");
        Application.LoadLevel("Level2");
    }

    public void Level3()
    {
        Debug.Log("I've loaded Level 3 :)");
        Application.LoadLevel("Level3");
    }

    public void Level4()
    {
        Debug.Log("I've loaded Level 4 :)");
        Application.LoadLevel("Level4");
    }
}
