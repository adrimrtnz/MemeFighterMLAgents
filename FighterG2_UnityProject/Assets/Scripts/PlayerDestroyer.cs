/// @file PlayerDestroyer.cs
/// @brief Script encargado de detectar colisiones y eliminar al jugador si es necesario.
///
/// Este script destruye el objeto jugador cuando entra en contacto con un objeto con la etiqueta "Destroy".
/// En lugar de destruir directamente el objeto, llama al método `Kill()` del componente `Atributos`.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// @class PlayerDestroyer
/// @brief Gestiona la destrucción del jugador cuando colisiona con ciertos objetos.
public class PlayerDestroyer : MonoBehaviour
{
    /// @brief Detecta colisiones con objetos que tienen la etiqueta "Destroy".
    ///
    /// @param colision El objeto con el que ha colisionado.
    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.CompareTag("Destroy"))
        {
            GetComponent<Atributos>().Kill();
        }
    }
}
