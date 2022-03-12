using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject gameManager;
    public int vidasGlobal;
    public int puntuacionGlobal;
    public string mensajeFinal;

    public Canvas canvas;
    private ControlHUD hud;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        DontDestroyOnLoad(gameManager);
        SceneManager.LoadScene("Menu");

        hud = canvas.GetComponent<ControlHUD>();
        hud.setVidasTxt(vidasGlobal);
    }
    public void cambiarEscena(string siguienteScene)
    {
        SceneManager.LoadScene(siguienteScene);
    }
    // Update is called once per frame
    void Update()
    {

    }

    public int getVidas()
    {
        return vidasGlobal;
    }

    public int getPuntuacionGlobal()
    {
        return puntuacionGlobal;
    }
    public string getMensajeFinal()
    {
        return mensajeFinal;
    }

    public void decrementarVidas()
    {
        vidasGlobal--;
        hud.setVidasTxt(vidasGlobal);
    }
    public void aumentarPuntuacion()
    {
        puntuacionGlobal++;
        hud.setPuntuacionTxt(puntuacionGlobal);
    }
    public void inicializarVidas()
    {
        vidasGlobal = 3;
    }
    public void TerminarJuego(bool ganar)
    {
        mensajeFinal = (ganar) ? "Felicidades has terminado el juego" : "Has perdido";
        cambiarEscena("Final");
    }
}
