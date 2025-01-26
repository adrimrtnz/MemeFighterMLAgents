using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.CompareTag("Destroy"))
        {
            // Destroy(this.gameObject);
            GetComponent<Atributos>().Kill();
        }
    }
}
