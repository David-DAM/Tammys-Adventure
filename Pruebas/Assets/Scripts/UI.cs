using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    public GameObject optionsPanel;

    public void pause()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
    }

    public void play()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }

    public void restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
