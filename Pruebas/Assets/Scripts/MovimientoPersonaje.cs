using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float fuerzaSalto;
    public float velocidad;
    public int puntuacion;
    public AudioClip impacto;
    public AudioClip salto;
    public AudioClip puntuar;
    AudioSource audioSource;

    private Rigidbody2D rigidbody2D;
    SpriteRenderer sprd;

    private Animator animator;

    bool isJumping = false;
    int contador=0;

    public int numVidas=5;
    public bool vulnerable=true;

    private GameManager gameManager;
    public Joystick joystick;
    [Range(1, 500)] public float potenciaSalto;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        sprd = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void FixedUpdate()
    {
        //gameManager.FixedUpdate();
        
        float movimientoH = Input.GetAxisRaw("Horizontal");
        rigidbody2D.velocity = new Vector2(movimientoH*velocidad,rigidbody2D.velocity.y);

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
            contador++;
        }

        if (contador == 160)
        {
            animator.SetBool("timeEnought", true);
            contador = 0;
        }
        else
        {
            animator.SetBool("timeEnought", false);
        }

        if (Input.GetButton("Jump") && !isJumping)
        {
            rigidbody2D.AddForce(Vector2.up * fuerzaSalto);
            isJumping = true;
            animator.SetBool("isJumping", true);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
        
        
        
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
        /*
        if ((movimientoV >= .5f) && (!isJumping))
        {
            rigidbody2D.AddForce(Vector2.up * fuerzaSalto);
            isJumping = true;
        }
        */
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isJumping = false;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
        }
    }

    public void IncrementarPuntos()
    {
        audioSource.PlayOneShot(puntuar);
        gameManager.aumentarPuntuacion();
    }

    public void QuitarVida()
    {
        if (vulnerable)
        {
            vulnerable = false;

            audioSource.PlayOneShot(impacto);
            gameManager.decrementarVidas();

            if (gameManager.getVidas() == 0)
            {
                gameManager.TerminarJuego(false);
            }

            Invoke("HacerVulnerable", 1f);
            sprd.color = Color.grey;
        }
    }

    private void HacerVulnerable()
    {
        vulnerable = true;
        sprd.color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            gameManager.TerminarJuego(true);
        }
    }

    public void setJoystick(Joystick joystick)
    {
        this.joystick = joystick;
    }

    public void accionBoton()
    {
        if (!isJumping)
        {
            audioSource.PlayOneShot(salto);
            rigidbody2D.AddForce(Vector2.up * fuerzaSalto);
            isJumping = true;
        }

    }

}
