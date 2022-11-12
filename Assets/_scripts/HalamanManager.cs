using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanManager : MonoBehaviour
{
    public bool isEscapeToExit;
    public static HalamanManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void StartGame(int levelGame)
    {
        if (levelGame == 1)
        {
            SceneManager.LoadScene("SceneLevel1");
        }
        else if (levelGame == 2)
        {
            SceneManager.LoadScene("SceneLevel2");
        }
    }

    public void tutorScene()
    {
        SceneManager.LoadScene("SceneTutor");
    }

    public void infoScene()
    {
        SceneManager.LoadScene("SceneInfo");
    }

    public void KembaliKeMainMenu()
    {
        SceneManager.LoadScene("SceneMainMenu");
    }

    public void exitGame()
    {
        // will work on build version
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isEscapeToExit)
            {
                // will work on build version
                Application.Quit();
            }
            else
            {
                KembaliKeMainMenu();
            }
        }
    }

}
