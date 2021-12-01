using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueComunist : MonoBehaviour
{

    public float speed = 1f;

    public float speedRotacón = 5f;

    public float tiempVida = 5f;

    //Saber hacia que lado lanzar el logo comunista

    public Movimiento movim;

    //en el primer frame
    private void Start()
    {
        //mover el logo comunista en la dirección corecta
        if (movim.mirandoderecha)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
        }
    }

    // Se llama una vez por frame
    void Update()
    {
        //mover el logo comunista 

        transform.Translate(speed * Time.deltaTime, 0, 0);

        //rotar el logo comunista
        transform.Rotate(0f, 0f, 1f*Time.deltaTime* speedRotacón);

        //Eliminar el logo comunista después de unos segundos (si no ha chocado con nada)

        Invoke("Eliminarbala", tiempVida);
    }

    private void Eliminarbala()
    {
        Destroy(gameObject);
    }


}
