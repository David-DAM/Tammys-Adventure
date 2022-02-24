using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float fuerzaSalto;
    public float velocidad;

    private Rigidbody2D rigidbody2D;
    private float horizontal;
    private bool enTierra;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Debug.DrawRay(transform.position, Vector3.down*0.1f,Color.red);
        if (Physics2D.Raycast(transform.position,Vector3.down,0.1f))
        {
            enTierra = true;
        }
        else
        {
            enTierra = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && enTierra)
        {
            rigidbody2D.AddForce(Vector2.up*fuerzaSalto);
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(horizontal*velocidad,rigidbody2D.velocity.y); 
    }
}
