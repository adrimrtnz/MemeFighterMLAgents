using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Colision : MonoBehaviour
{
    public Vector2 potenciaV2;
    public float daño;
    public GameObject Parent = null; //Sólo para especial bunny

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            
        {
            if (collision.gameObject.GetComponent<Movimiento>() != null) collision.gameObject.GetComponent<Movimiento>().BunnyGolpeado();
            else if (collision.gameObject.GetComponent<Movimiento2>() != null) collision.gameObject.GetComponent<Movimiento2>().damaged = true;
            else if (collision.gameObject.GetComponent<Bunny_Agent>() != null) { 
                collision.gameObject.GetComponent<Bunny_Agent>().BunnyGolpeado();
                Debug.LogWarning(transform.parent.name + " <<<<<<<<<<<<<<<<<<<<<<<<");
                transform.parent.GetComponent<Doge_Agent>().HandleHitEnemyReward();
            }
            else if (collision.gameObject.GetComponent<Doge_Agent>() != null) { 
                collision.gameObject.GetComponent<Doge_Agent>().DoggeGolpeado();
                Debug.LogWarning(transform.parent.name + " <<<<<<<<<<<<<<<<<<<<<<<<");
                if (Parent == null)
                {
                    transform.parent.GetComponent<Bunny_Agent>().HandleHitEnemyReward();
                }
                else { Parent.GetComponent<Bunny_Agent>().HandleHitEnemyReward(); } 
            }

            bool killed = false;
            if (this.gameObject.transform.position.x < collision.gameObject.transform.position.x)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(1 * potenciaV2.x, potenciaV2.y));
                killed = collision.GetComponent<Atributos>().changeHP(-daño);
            } else if (this.gameObject.transform.position.x > collision.gameObject.transform.position.x)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1 * potenciaV2.x, potenciaV2.y));
                killed = collision.GetComponent<Atributos>().changeHP(-daño); 
            }
            if (killed) {
                if (GetComponent<Bunny_Agent>() != null)
                {
                    GetComponent<Bunny_Agent>().HandleKillEnemyReward();
                }
                else if (GetComponent<Doge_Agent>() != null)
                {
                    GetComponent<Doge_Agent>().HandleKillEnemyReward();
                }
            }

        }


    }
}
