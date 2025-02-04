/// @file logo_creator_attack.cs
/// @brief Script encargado de generar un logo comunista en el juego.
///
/// Este script permite instanciar un objeto en un punto espec�fico y asignarle propiedades,
/// como su posici�n y su relaci�n con el objeto padre.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// @class logo_creator_attack
/// @brief Controla la generaci�n de un logo comunista en el juego.
public class logo_creator_attack : MonoBehaviour
{
    /// @brief Prefab del objeto a instanciar (logo comunista).
    public Rigidbody2D comunismo;
    /// @brief Punto de spawn donde se generar� el logo.
    public Transform puntoSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        
    }


    /// @brief M�todo que instancia el logo comunista en la escena.
    public void SpawnLogoComun2()
    {
        Rigidbody2D c = Instantiate(comunismo, puntoSpawn.position, puntoSpawn.rotation);
        c.GetComponentInChildren<Colision>().Parent = gameObject;
    }
}
