using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
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
}
