/// @file Seguir.cs
/// @brief Script para seguir un objetivo en la escena, utilizado en Cinemachine.
///
/// Este script ajusta la posición del objeto al de un target específico, generalmente un jugador,
/// en el contexto de peleas dentro del juego.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// @class Seguir
/// @brief Se encarga de seguir a un objetivo (jugador) en la escena.
public class Seguir : MonoBehaviour
{

    /// @brief Transform del objetivo a seguir.
    public Transform target;

    /// @brief Identificador del jugador (1 o 2) para determinar a quién seguir.
    public int playerN;

    /// @brief Método FixedUpdate, ejecutado en cada frame de física, ajusta la posición del objeto.
    private void FixedUpdate()
    {
        try
        {
            if (target != null)
                transform.position = target.transform.position;
            else if (playerN == 1)
                target = transform.parent.gameObject.GetComponent<EventosPelea>().player1.transform;
            else if (playerN == 2) target = transform.parent.gameObject.GetComponent<EventosPelea>().player2.transform;
        }
        catch (NullReferenceException)
        {
            transform.position = new Vector3(0, 0, 0);

        }
    }
}
