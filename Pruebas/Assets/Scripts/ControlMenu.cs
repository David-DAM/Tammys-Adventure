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

    public void GameInfo() {
        SceneManager.LoadScene("InfoAssets");
    }

    public void SoundInfo() {
        SceneManager.LoadScene("InfoSonidos");
    }

    public void ToolsInfo() {
        SceneManager.LoadScene("InfoUtilidades");
    }


    public void OnButtonmenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
