using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameObject gameManager;
    public int vidasGlobal;
    private string mensajeFinal;

    public string MensajeFinal { get => mensajeFinal; set => mensajeFinal = value; }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        DontDestroyOnLoad(gameManager);
        SceneManager.LoadScene("Menu");
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

    public void decrementarVidas()
    {
        vidasGlobal--;
    }
    public void inicializarVidas()
    {
        vidasGlobal = 3;
    }
    public void TerminarJuego(bool ganar)
    {
        mensajeFinal = (ganar) ? "Felicidades has terminado el juego" : "Uuuuuuhhhhh has perdido";
        cambiarEscena("FINAL");
    }
}
