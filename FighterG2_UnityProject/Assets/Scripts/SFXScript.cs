/// @file SFXScript.cs
/// @brief Clase encargada de gestionar los efectos de sonido en el juego.
///
/// Este script permite la reproducción de diferentes efectos de sonido mediante un sistema basado en strings.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// @class SFXScript
/// @brief Gestiona la reproducción de efectos de sonido mediante un AudioSource.
public class SFXScript : MonoBehaviour
{
    /// @brief Referencia al componente AudioSource encargado de la reproducción.
    [Header("Sonidos")]
    public AudioClip Countdown;
    public AudioClip Hit1;
    public AudioClip Hit2;
    public AudioClip Hit3;
    public AudioClip Jump1;
    public AudioClip LowHit;
    public AudioClip Walk;

    /// @brief Clips de audio utilizados en el juego.
    [Header("Audio Source")]
    public AudioSource audioSrc;

    /// @brief Inicializa el script y reproduce el sonido de cuenta regresiva al inicio.
    private void Start()
    {
        PlaySound("Countdown");
    }

    /// @brief Reproduce un sonido basado en su identificador en formato string.
    ///
    /// @param clip Nombre del sonido a reproducir.
    public void PlaySound(string clip) { 
        switch (clip)
        {
            case "Countdown":
                audioSrc.PlayOneShot(Countdown);
                break;
            case "Hit1":
                audioSrc.PlayOneShot(Hit1);
                break;
            case "Hit2":
                audioSrc.PlayOneShot(Hit2);
                break;
            case "Hit3":
                audioSrc.PlayOneShot(Countdown);
                break;
            case "Jump1":
                audioSrc.PlayOneShot(Jump1);
                break;
            case "LowHit":
                audioSrc.PlayOneShot(LowHit);
                break;
            case "Walk":
                audioSrc.PlayOneShot(Walk);
                break;
            default:
                Debug.Log("El sonido" + clip + "No está especificado");
                break;

        }
    
    }
}
