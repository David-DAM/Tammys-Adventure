using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float fuerzaSalto;
    public float velocidad;
    public int puntuacion;

    private Rigidbody2D rigidbody2D;
    SpriteRenderer sprd;

    private Animator animator;

    bool isJumping = false;
    int contador=0;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        sprd = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void FixedUpdate()
    {
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isJumping = false;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
        }
    }

    public void IncrementarPuntos(int cantidad)
    {
        puntuacion += cantidad;
    }
}
