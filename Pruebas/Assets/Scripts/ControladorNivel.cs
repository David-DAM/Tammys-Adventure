using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class ControladorNivel : MonoBehaviour
{
    public static ControladorNivel instance;

    public Transform respawn;
    public GameObject jugador;

    public CinemachineVirtualCameraBase cam;

    private void Awake()
    {
        instance = this;        
    }

    public void Respawn()
    {
        GameObject player= Instantiate(jugador,respawn.position,Quaternion.identity);
        cam.Follow=player.transform;
    }
}
