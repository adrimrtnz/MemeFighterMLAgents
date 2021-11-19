using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agarrar : MonoBehaviour
{
    private Rigidbody2D rb;
    public float tiempo=3f;
    private float gravedad;
    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        gravedad = rb.gravityScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Saliente")
        {
            rb.gravityScale = 0f;
            rb.velocity = rb.velocity * 0.1f;

            Invoke("soltar", tiempo);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Saliente")
        {
            soltar();
        }

    }

    public void soltar() {
        rb.gravityScale = 10f;
    }


}