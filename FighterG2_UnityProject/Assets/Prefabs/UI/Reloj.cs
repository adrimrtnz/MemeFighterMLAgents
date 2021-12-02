using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Reloj : MonoBehaviour
{
    public TextMeshProUGUI reloj;
    public float tiempo;

   

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo / 60 >= 10)
        reloj.text ="" +  (int) (tiempo / 60) ;
        else reloj.text = "0" + (int)(tiempo / 60);
        if (tiempo %60 >= 10)
        reloj.text += ":" + (int)tiempo % 60;
        else reloj.text += ":0" + (int)tiempo % 60;

    }
}
