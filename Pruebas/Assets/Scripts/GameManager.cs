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

    public float fuerzaSalto;
    public float velocidad;
    public int puntuacion;

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer sprd;
    private Animator animator;
    bool isJumping = false;
    public Joystick joystick;
    [Range(1, 500)] public float potenciaSalto;

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
    public void FixedUpdate()
    {
     
        float movimientoH;
        if ((joystick.Horizontal >= .2f) | (joystick.Horizontal <= .2f))
        {
            movimientoH = joystick.Horizontal;
        }
        else
        {
            movimientoH = 0f;
        }

        rigidbody2D.velocity = new Vector2(movimientoH * velocidad, rigidbody2D.velocity.y);

        if (movimientoH > 0)
        {
            sprd.flipX = false;
        }
        else if (movimientoH < 0)
        {
            sprd.flipX = true;
        }

        if (movimientoH != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);

        }
        float movimientoV = joystick.Vertical;
        //if(Input.GetButton("Jump") && !isJumping)
        if ((movimientoV >= .5f) && (!isJumping))
        {
            rigidbody2D.AddForce(Vector2.up * potenciaSalto);
            isJumping = true;
        }
    }
}
