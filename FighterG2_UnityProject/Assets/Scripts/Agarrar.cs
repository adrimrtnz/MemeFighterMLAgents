/// @file Agarrar.cs
/// @brief Clase para manejar la mec�nica de agarre a salientes en un entorno 2D.
///
/// Esta clase permite que un objeto se agarre a una saliente cuando entra en contacto con ella,
/// desactivando la gravedad y activando una animaci�n. Despu�s de un tiempo determinado, el objeto se suelta.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// @class Agarrar
/// @brief Gestiona el comportamiento de agarre a una saliente y su posterior liberaci�n.
public class Agarrar : MonoBehaviour
{
    private Rigidbody2D rb; ///< Referencia al Rigidbody2D del objeto padre.
    public float tiempo=3f; ///< Tiempo que el objeto permanecer� agarrado antes de soltarse autom�ticamente.
    private float gravedad; ///< Almacena la gravedad original del objeto.

    public Animator anim; ///< Referencia al Animator para manejar las animaciones.

    /// @brief Inicializa las variables al comenzar el juego.
    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        gravedad = rb.gravityScale;
    }

    /// @brief Detecta cuando el objeto entra en contacto con una saliente.
    /// @param collision El collider con el que se ha colisionado.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Saliente")
        {
            //Animaci�n estar en saliente
            anim.SetBool("saliente",true);

            // Desactiva la gravedad y reduce la velocidad para "agarrarse" a la saliente.
            rb.gravityScale = 0f;
            rb.velocity = rb.velocity * 0.1f;

            // Programa la acci�n de soltar despu�s de un tiempo determinado.
            Invoke("soltar", tiempo);
        }

    }

    /// @brief Detecta cuando el objeto sale del �rea de la saliente.
    /// @param collision El collider con el que se ha colisionado.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Saliente")
        {
            soltar();
        }

    }

    /// @brief Suelta el objeto restaurando la gravedad y desactivando la animaci�n de estar en saliente.
    public void soltar() {
        rb.gravityScale = 10f;
        //Animaci�n estar en saliente
        anim.SetBool("saliente", false);
    }
}