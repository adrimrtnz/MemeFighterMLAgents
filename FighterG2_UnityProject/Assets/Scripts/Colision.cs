/// @file Colision.cs
/// @brief Maneja la detección de colisiones y la aplicación de daño a los jugadores.
///
/// Esta clase detecta cuando un objeto entra en contacto con un jugador y aplica daño,
/// además de gestionar efectos de retroceso y recompensas en el sistema de aprendizaje automático.

using UnityEngine;


/// @class Colision
/// @brief Controla la detección de colisiones y aplica efectos correspondientes.
public class Colision : MonoBehaviour
{
    public Vector2 potenciaV2;  ///< Fuerza aplicada al jugador cuando es golpeado.
    public float daño;  ///< Cantidad de daño infligido al jugador.
    public GameObject Parent = null; ///< Objeto que originó la colisión (usado solo en ataques especiales de Bunny).

    /// @brief Maneja la colisión con otros objetos.
    /// @param collision Collider del objeto con el que se ha colisionado.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            
        {
            // Aplica efectos según el tipo de objeto colisionado
            if (collision.gameObject.GetComponent<Movimiento>() != null) 
                collision.gameObject.GetComponent<Movimiento>().BunnyGolpeado();
            else if (collision.gameObject.GetComponent<Movimiento2>() != null) 
                collision.gameObject.GetComponent<Movimiento2>().damaged = true;
            else if (collision.gameObject.GetComponent<Bunny_Agent>() != null) { 
                collision.gameObject.GetComponent<Bunny_Agent>().BunnyGolpeado();
                if (Parent.GetComponent<Doge_Agent>() != null)
                {
                    Parent.GetComponent<Doge_Agent>().HandleHitEnemyReward();
                }
                else if (Parent.GetComponent<Bunny_Agent>() != null) {
                    // Se ha dado a si mismo
                }
            }
            else if (collision.gameObject.GetComponent<Doge_Agent>() != null) { 
                collision.gameObject.GetComponent<Doge_Agent>().DoggeGolpeado();
                if (Parent == null)
                {
                    Parent.GetComponent<Bunny_Agent>().HandleHitEnemyReward();
                }
                else { Parent.GetComponent<Bunny_Agent>().HandleHitEnemyReward(); } 
            }

            // Aplicar fuerza y daño
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

            // Gestionar recompensas si el enemigo es eliminado
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
