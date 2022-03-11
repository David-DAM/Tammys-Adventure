using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    GameManager gameManager;

    public void OnButtonJugar()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.inicializarVidas();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void onButtonCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void OnButtonSalir()
    {
        Application.Quit();
    }

    public void OnButtonmenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
