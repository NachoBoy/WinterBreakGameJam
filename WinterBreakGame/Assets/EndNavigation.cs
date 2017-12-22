﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndNavigation : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void ReturntoMain()
    {
        Debug.Log("Main");
        SceneManager.LoadScene(0);
    }
}
