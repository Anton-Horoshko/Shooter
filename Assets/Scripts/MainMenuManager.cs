using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex); 
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}