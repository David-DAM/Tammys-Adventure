using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public GameObject personaje;

    private void Update()
    {
        Vector3 posicion = transform.position;
        posicion.x = personaje.transform.position.x;
        transform.position = posicion;
    }
}
