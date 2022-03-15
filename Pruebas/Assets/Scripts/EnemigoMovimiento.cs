using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovimiento : MonoBehaviour
{
    public float velocidad;
    public Vector3 posicionFin;

    private Vector3 posicionInicio;
    private bool movimiendoFin;
    SpriteRenderer sprd;

    public bool toFlip;

    // Start is called before the first frame update
    public void Start()
    {
        posicionInicio = transform.position;
        sprd = GetComponent<SpriteRenderer>();
        movimiendoFin = true;
    }

    // Update is called once per frame
    void Update()
    {
        moverEnemigo();
    }

    private void moverEnemigo()
    {
        Vector3 posicionDestino = (movimiendoFin) ? posicionFin : posicionInicio;

        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);

        if (transform.position == posicionFin)
        {
            movimiendoFin = false;
            if (toFlip)
            {
                sprd.flipX = true;
            }
        }

        if (transform.position == posicionInicio)
        {
            movimiendoFin = true;
            if (toFlip)
            {
                sprd.flipX = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<MovimientoPersonaje>().QuitarVida();
        }
    }

    
}
