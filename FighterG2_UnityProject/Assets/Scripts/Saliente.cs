using System.Collections.Generic;
using UnityEngine;

public class Saliente : MonoBehaviour
{
    public Rigidbody2D rb;
    public float tiempo;


    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Saliente")
        {
            rb.velocity = Vector2.zero;
            rb.gravityScale=0f;
            CancelInvoke("peso");
            Invoke("peso", tiempo);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Saliente")
        {
            peso();
        }
    }

    private void peso()
    {
        rb.gravityScale = 10f;
    }
}
