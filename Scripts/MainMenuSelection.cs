using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSelection : MonoBehaviour
    //Kieran Lewis 2018 :) 
{
    public GameObject dean;
    public GameObject PauseMenu;

    //Boolean for the player to pause the game
    public bool pause = true;

	void Start ()
    {
        
        //This is for the pause function of the game, the time scale will be set to 0 when the player presses pause
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);

        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        //Debug Cheats
        //Pressing 1 loads level 1, 2 loads level 2, 3 loads level 3 and 4 loads level 4
        //This was used before the Level Select was a seperate scene
        if (sceneName == "MainMenu")
        {
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
      
        //Handling the pause function in the game
        //The player cannot pause if they are not on one of the main levels
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (sceneName == "Level1" || sceneName == "Level2" || sceneName == "Level3" || sceneName == "Level4")
            {
                paused();
            }
           
        }
       
    }

    public void Play()
    {
        //When New Game is pressed then the first level will load.
        Debug.Log("Level 1 has loaded efficiently");
        SceneManager.LoadScene("Level1");
    }
    public void paused()
    {
        if (pause)
        {
            //Set the game's timescale to 0 to freeze everything
            Time.timeScale = 0;
            //Disable Dean so that the player cannot control him
            dean.SetActive(false);
            //Activate the pause menu
            PauseMenu.SetActive(true);
            //The player can now unpause the game
            pause = false;
            
        }
        else
        {
            //Se the game's timescale to 1 to unfreeze everything
            Time.timeScale = 1;
            //Reactivate Dean
            dean.SetActive(true);
            //Disable the Pause Menu
            PauseMenu.SetActive(false);
            //The player can pause again
            pause = true;
        }
      
        
    }

    public void Help()
    {
        //When the help button is pressed then the help menu will show
        Debug.Log("Help Menu has loaded");
        SceneManager.LoadScene("Help");
    }

    public void Quit()
    {
        //The game will quit when the quit button has been pressed
        Application.Quit();
    }

    public void mainMenu()
    {
        Debug.Log("Main Menu has loaded");
        SceneManager.LoadScene("MainMenu");
    }

    public void restartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Debug.Log("Level will be restarted");
        SceneManager.LoadScene(sceneName);
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    //This is now going to be used for the level selection at the main menu
    public void Level1()
    {
        Debug.Log("I've loaded Level 1 :)");
        SceneManager.LoadScene("Level1");
    }

    public void Level2()
    {
        Debug.Log("I've loaded Level 2 :)");
        SceneManager.LoadScene("Level2");
    }

    public void Level3()
    {
        Debug.Log("I've loaded Level 3 :)");
        SceneManager.LoadScene("Level3");
    }

    public void Level4()
    {
        Debug.Log("I've loaded Level 4 :)");
        SceneManager.LoadScene("Level4");
    }
}
