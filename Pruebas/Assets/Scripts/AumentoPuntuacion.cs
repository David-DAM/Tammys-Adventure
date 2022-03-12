using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentoPuntuacion : MonoBehaviour
{
    public ParticleSystem colisionParticulas;
    public SpriteRenderer sprite;
    public bool repe=true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<MovimientoPersonaje>().IncrementarPuntos();

        if (repe)
        {
            var em = colisionParticulas.emission;
            var dur = colisionParticulas.duration;

            em.enabled = true;
            colisionParticulas.Play();

            repe = false;

            Destroy(sprite);
            Invoke(nameof(DestroyObj), dur);
        }
        
    }

    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
