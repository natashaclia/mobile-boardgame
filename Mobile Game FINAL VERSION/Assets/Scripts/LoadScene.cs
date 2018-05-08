using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 * this class handles the action of switching between scenes in the game application.
 * e.g. between the MainMenu screen and Main screen (gameplay), when the designated button 
 * is pressed.
 */

public class LoadScene : MonoBehaviour {

    public void sceneLoader(string sceneName)
    {
        // loads specified screen, on click()
        SceneManager.LoadScene(sceneName);
    }
}
