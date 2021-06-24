using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour
{

    private bool GameIsPaused = false;
    public GameObject PauseMenu;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    
    }


    public void ToGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main_Menu", LoadSceneMode.Single);
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    public void QuitGame()
    {
        Application.Quit();
    }


}
