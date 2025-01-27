using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logo_creator_attack : MonoBehaviour
{
    public Rigidbody2D comunismo;
    public Transform puntoSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        
    }


    //Spawnear logo comunista
    public void SpawnLogoComun2()
    {
        //Spaunear logo comunista
        Instantiate(comunismo, puntoSpawn.position, puntoSpawn.rotation);
    }
}
