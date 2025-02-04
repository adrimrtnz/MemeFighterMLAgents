/// @file AtaqueComunist.cs
/// @brief Clase para manejar el ataque comunista en un entorno 2D.
///
/// Esta clase controla el movimiento, rotación y eliminación automática de un proyectil comunista.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// @class AtaqueComunist
/// @brief Gestiona el movimiento y la rotación del proyectil comunista.
public class AtaqueComunist : MonoBehaviour
{

    public float speed = 1f;            ///< Velocidad de desplazamiento del proyectil.
    public float speedRotacón = 5f;     ///< Velocidad de rotación del proyectil.
    public float tiempVida = 5f;        ///< Tiempo antes de que el proyectil sea destruido.

    /// @brief Referencia al script Movimiento para determinar la dirección inicial.
    public Movimiento movim;

    /// @brief Se ejecuta en el primer frame para determinar la dirección inicial del proyectil.
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

    /// @brief Se ejecuta en cada frame para actualizar el movimiento y la rotación.
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);          ///< Movimiento continuo del proyectil.
        transform.Rotate(0f, 0f, 1f*Time.deltaTime* speedRotacón);  ///< Rotación del proyectil.
        Invoke("Eliminarbala", tiempVida);                          ///< Destruir el proyectil tras cierto tiempo.
    }

    /// @brief Elimina el proyectil destruyendo el objeto.
    private void Eliminarbala()
    {
        Destroy(gameObject);
    }


}
