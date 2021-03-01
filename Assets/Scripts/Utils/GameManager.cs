using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * CIS 497_2 : Design Patterns
 * Group Project 1 - XenoGarden
 * Contributed by: Wolfgang Gross 
 */

public class GameManager : Singleton<GameManager>
{
    //public GameObject pauseMenu;

    private string CurrentLevelName = string.Empty;

    #region This code makes this class a Singleton
    //Done by Singleton Class
    /*
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            //Make sure this game manager persists across scenes\
            DontDestroyOnLoad(gameObject);
            
            
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Trying to instatiate a second instance of singleton Game Manager");
        }


    }
    */
    #endregion

    //methods to load and unload scenes
    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to load level " + levelName);
            return;
        }
        CurrentLevelName = levelName;
    }

    public void UnLoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + levelName);
            return;
        }
    }

    public void UnloadCurrentLevel()
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(CurrentLevelName);
        if (ao == null)
        {
            Debug.LogError("[GameManager] Unable to unload level " + CurrentLevelName);
            return;
        }
    }

    //pausing and unpausing

    public void Pause()
    {
        Time.timeScale = 0f;
        //pauseMenu.SetActive(true);
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
        //pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            UnPause();
        }
    }



}
