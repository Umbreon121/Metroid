using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Vila, Mondo
//Edwards, Eric
//11/13/23
//Metroid Main Menu

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Quits the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    /// <summary>
    /// Switches scene to play the game
    /// </summary>
    /// <param name="sceneIndex"></param>
    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
