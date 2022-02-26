using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoPincho : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            ControladorNivel.instance.Respawn();
        }
    }
}
