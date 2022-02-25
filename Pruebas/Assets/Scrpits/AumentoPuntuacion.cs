using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentoPuntuacion : MonoBehaviour
{
    public int cantidad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<MovimientoPersonaje>().IncrementarPuntos(cantidad);
        Destroy(gameObject);
    }
}
