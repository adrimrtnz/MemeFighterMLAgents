using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour
{
    [Header("Sonidos")]
    public AudioClip Countdown;
    public AudioClip Hit1;
    public AudioClip Hit2;
    public AudioClip Hit3;
    public AudioClip Jump1;
    public AudioClip LowHit;
    public AudioClip Walk;

    [Header("Audio Source")]
    public AudioSource audioSrc;

    private void Start()
    {
        PlaySound("Countdown");
    }

    // Aquí se pasará una string para decidir qué sonido reproducir
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
