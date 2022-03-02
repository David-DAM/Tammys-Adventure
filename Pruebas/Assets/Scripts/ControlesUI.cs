using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlesUI : MonoBehaviour
{
    bool izquierda = false;
    bool derecha = false;

    public Rigidbody2D rb;
    public float velocidad;
    public Animator animator;
    public SpriteRenderer sprd;


    public void clickizq()
    {
        izquierda = true;
    }

    public void soltarizq()
    {
        izquierda = false;
    }

    public void clickder()
    {
        derecha = true;
    }

    public void soltarder()
    {
        derecha = false;
    }

    private void FixedUpdate()
    {
    

         if (izquierda)
         {
            rb.AddForce(new Vector2(-velocidad, 0) * Time.deltaTime);
            animator.SetBool("isWalking", true);
            sprd.flipX = true;

        }
         else if (derecha)
         {
            rb.AddForce(new Vector2(velocidad, 0) * Time.deltaTime);
            animator.SetBool("isWalking", true);
            sprd.flipX = false;
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        

    }

}
