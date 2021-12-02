using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Seguir : MonoBehaviour
{

    //Este script se utiliza para el cinemachine

    public Transform target;
    public int playerN;
    // Start is called before the first frame update
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
