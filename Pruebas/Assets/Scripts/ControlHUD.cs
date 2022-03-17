using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ControlHUD : MonoBehaviour
{
    public TextMeshProUGUI vidasTxt;
    public TextMeshProUGUI puntuacionTxt;
    public GameObject optionsPanel;

    public void setVidasTxt(int vidas)
    {
        vidasTxt.text =""+vidas;
    }

    public void setPuntuacionTxt(int cantidad)
    {
        puntuacionTxt.text =""+cantidad;
    }


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

    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        optionsPanel.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }
}
