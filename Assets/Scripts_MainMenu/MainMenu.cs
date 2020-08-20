using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(6);

    }

    public void HelpMenu()
    {
        SceneManager.LoadScene(7);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

}
