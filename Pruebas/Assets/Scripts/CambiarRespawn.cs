using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarRespawn : MonoBehaviour
{
    public GameObject nuevoRespawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ControladorNivel.instance.respawn = nuevoRespawn;
    }
}
