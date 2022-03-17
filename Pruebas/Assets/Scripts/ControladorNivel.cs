using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;



public class ControladorNivel : MonoBehaviour
{
    public static ControladorNivel instance;

    public GameObject respawn;
    public GameObject jugador;
   

    private void Awake()
    {
        instance = this;        
    }

    public void reaparecer()
    {
        jugador.transform.position = respawn.transform.position;
    }
}
