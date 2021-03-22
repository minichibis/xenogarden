using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject encyclopediaScreen;
    private bool inEncyclopedia = false;

    public void pause()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void resume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void encyclopedia()
    {
        inEncyclopedia = true;
        encyclopediaScreen.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (inEncyclopedia)
            {
                encyclopediaScreen.SetActive(false);
                inEncyclopedia = false;
            }
        }
    }
}
