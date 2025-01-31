using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    public Vector2 potenciaV2;
    public float daño;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            
        {
            if (collision.gameObject.name == "BunnyP1") collision.gameObject.GetComponent<Movimiento>().BunnyGolpeado();
            else if (collision.gameObject.name == "Doge") collision.gameObject.GetComponent<Movimiento2>().damaged = true;
            else if (collision.gameObject.name == "BunnyP1_Agent") { 
                collision.gameObject.GetComponent<Bunny_Agent>().BunnyGolpeado();
                transform.parent.GetComponent<Doge_Agent>().HandleHitEnemyReward();
            }
            else if (collision.gameObject.name == "Doge_agent") { 
                collision.gameObject.GetComponent<Doge_Agent>().DoggeGolpeado();
                transform.parent.GetComponent<Bunny_Agent>().HandleHitEnemyReward();
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
