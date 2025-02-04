/// @file ObservableFloat.cs
/// @brief Clase que encapsula un valor flotante observable.
///
/// Esta clase permite la monitorización de cambios en un valor flotante (`float`) y
/// notifica a los suscriptores cuando dicho valor cambia. Es útil para la programación
/// basada en eventos dentro de Unity.

using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// @class ObservableFloat
/// @brief Permite observar cambios en un valor flotante y notificar a los suscriptores.
public class ObservableFloat : MonoBehaviour
{
    /// @brief Valor flotante interno almacenado.
    private float m_Value;

    /// @brief Evento que se dispara cuando el valor cambia.
    ///
    /// Los suscriptores recibirán el nuevo valor como parámetro cuando este cambie.
    public event Action<float> OnValueChanged;

    /// @brief Propiedad que maneja la actualización del valor observable.
    ///
    /// Al cambiar el valor, se notifica a los suscriptores solo si el nuevo valor es diferente.
    public float Value
    {
        get => m_Value;
        set
        {
            if (this.m_Value != value)
            {
                this.m_Value = value;
                OnValueChanged?.Invoke(this.m_Value);
            }
        }
    }

    /// @brief Constructor que inicializa el valor flotante con un valor opcional.
    ///
    /// @param iniValue Valor inicial del flotante (por defecto, `0f`).
    public ObservableFloat(float iniValue = 0f) 
    {
        this.m_Value = iniValue;
    }
}
