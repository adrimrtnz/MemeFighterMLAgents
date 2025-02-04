/// @file Doge_Agent.cs
/// @brief Clase que representa un agente de IA en Unity ML-Agents.
///
/// Esta clase define el comportamiento de un agente controlado por ML-Agents,
/// incluyendo movimiento, ataques y recompensas.


using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;
using System;

/// @class Doge_Agent
/// @brief Implementa un agente de ML-Agents con mecánicas de combate y movimiento.
public class Doge_Agent : Agent
{
    [SerializeField] private GameObject enemy;   ///< Referencia al enemigo en la escena.
    [SerializeField] private float speedFactor = 1.0f;  ///< Factor de velocidad de movimiento.
    [SerializeField] private float movementSpeed = 100.0f;  ///< Velocidad de movimiento del agente.

    [Header("SFX")] public SFXScript sfx;
    [SerializeField] public Animator agentAnimator;

    [Header("Cositas de pegarse a las paredes")]
    [SerializeField] public bool pared;
    [SerializeField] public float diagonal = 1f;
    [SerializeField] public float gpared = 7.0f;

    [Header("Salto")]
    public float fuerzasalto = 4000f;   ///< Fuerza aplicada al saltar.
    public int nsaltos = 0;             ///< Contador de saltos realizados.
    public int saltostotales = 2;       ///< Número total de saltos permitidos.
    private bool canJump = true;        ///< Indica si el agente puede saltar.
    public float stiempo = 0.3f;        ///< Tiempo de inactividad tras un salto.
    public float timeRate = 2f;         ///< Ratio de tiempo entre saltos.

    [Header("Golpes")]
    public float td = 0.3f;     ///< Duración del golpe normal.
    public float tf = 0.3f;     ///< Duración del golpe fuerte.
    public float te = 0.5f;     ///< Duración del ataque especial.
    public bool damaged;        ///< Indica si el agente ha recibido daño.

    private Rigidbody2D rb;
    private float gravity;
    private int movementAction;
    private int attackAction;
    private bool lookingToTheRight = false;
    private Atributos atributos;
    private float velocityY = 0f;

    /// @brief Devuelve si el agente está mirando a la derecha.
    public bool LookingToTheRigh {  get => lookingToTheRight; }

    Dictionary<int, Action> movementActions = new Dictionary<int, Action>();
    Dictionary<int, Action> attackActions = new Dictionary<int, Action>();

    /************ LISTENERS RECOMPENSAS ************/
    private float currentHealth;

    private void Awake()
    {
        atributos = GetComponent<Atributos>();
        atributos.setHP(atributos.maxHP);
        atributos.setEsp(0);

        currentHealth = atributos.getHP();

        // Mapeo de acciones de movimiento.
        movementActions.Add(0, DoNotMove);
        movementActions.Add(1, MoveRight);
        movementActions.Add(2, MoveLeft);
        movementActions.Add(3, Jump);

        // Mapeo de acciones de ataque.
        attackActions.Add(0, () => { /* Accion vacia: no atacar */ });
        attackActions.Add(1, Punch);
        attackActions.Add(2, PunchF);
        attackActions.Add(3, PunchE);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
        if (sfx == null) sfx = GameObject.Find("SFXManager").GetComponent<SFXScript>();
    }

    private void Update()
    {
        velocityY = rb.velocity.y;
        //Poner la velocidad en positivo
        if (rb.velocity.y < 0)
        {
            velocityY = velocityY * -1;
        }
    }


    /************ Para animator Doge ************/
    void FixedUpdate() 
    {
        // a.SetBool("Damaged", damaged);
        if (rb.velocity.y == 0) agentAnimator.SetBool("Ground", true);
        else agentAnimator.SetBool("Ground", false);
        if (rb.velocity.x != 0) agentAnimator.SetBool("Hmove", true);
        else agentAnimator.SetBool("Hmove", false); 
        if (rb.gravityScale == 0) agentAnimator.SetBool("pared", true); 
        else {
            if (pared == false) agentAnimator.SetBool("Pared", false);
            else agentAnimator.SetBool("Pared", true);
        }
        agentAnimator.SetFloat("VSpeed", rb.velocity.y);
    }

    /// @brief Reinicia el episodio cuando se inicia o termina.
    public override void OnEpisodeBegin()
    {
        //transform.position = new Vector3(18.2f, 12.6f, 0);
        atributos.setHP(atributos.maxHP);
        atributos.setEsp(0);
    }

    /// @brief Recopila observaciones del entorno para el agente.
    public override void CollectObservations(VectorSensor sensor)
    {
        // Saber donde estoy
        sensor.AddObservation(transform.localPosition);

        // Saber donde esta mi enemigo
        sensor.AddObservation(enemy.transform.localPosition);

        // Mi vida
        sensor.AddObservation(atributos.getHP());

        // Su vida
        sensor.AddObservation(enemy.GetComponent<Atributos>().getHP());

        // Mi Orientacion
        sensor.AddObservation(lookingToTheRight);

        // Su Orientacion
        sensor.AddObservation(enemy.GetComponent<Bunny_Agent>().LookingToTheRigh);

        // Saber cuantos saltos puedo hacer
        sensor.AddObservation(saltostotales);

        // Saber el conteo de saltos actuales
        sensor.AddObservation(nsaltos);

        // Saber si puedo saltar
        sensor.AddObservation(canJump);
    }

    /// @brief Maneja las acciones del agente.
    public override void OnActionReceived(ActionBuffers actions)
    {
        movementAction = actions.DiscreteActions[0];
        attackAction = actions.DiscreteActions[1];

        // Ejecuta movimiento (si lo hay)
        if (movementActions.ContainsKey(movementAction))
        {
            movementActions[movementAction]();
        }

        // Ejecuta ataque (si lo hay)
        if (attackActions.ContainsKey(attackAction))
        {
            attackActions[attackAction]();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {

        /*
         * Aqui podemos mapear controles a acciones para testear
         * que lo estamos mapeando bien (Behaviou type = Heurystic Only)
         * 
         * if (input de movimiento el que sea){
         *      actions.DiscreteActions[0] = 1;
         *  }
         *  
         *  
         *  if (input de atque el que sea){
         *      actions.DiscreteActions[0] = 1;
         *  }
         */
    }

    private void DoNotMove()
    {
        //agentAnimator.SetBool("correr", false);
    }

    private void MoveLeft()
    {
        if (lookingToTheRight)
        {
            transform.Rotate(0f, -180f, 0f, Space.World);
            lookingToTheRight = false;
        }
        Vector2 x = new Vector2(speedFactor, 0f);
        rb.AddForce(x * (-movementSpeed), ForceMode2D.Force);
    }

    private void MoveRight()
    {
        if (!lookingToTheRight)
        {
            transform.Rotate(0f, -180f, 0f, Space.World);
            lookingToTheRight = true;
        }
        Vector2 x = new Vector2(speedFactor, 0f);
        rb.AddForce(x * movementSpeed, ForceMode2D.Force);
    }

    private void Jump()
    {
        Vector2 saltito;
        if (nsaltos < saltostotales && canJump == true)
        {
            saltito = new Vector2(0f, 1f);
            if (pared)
            {
                if (lookingToTheRight)
                {
                    saltito = new Vector2(-diagonal, 1f);
                }
                else
                {
                    saltito = new Vector2(diagonal, 1f);
                }

            }
            //Aquí el sonido
            sfx.PlaySound("Jump1");
            //Aquí la fuerza
            rb.AddForce(saltito * fuerzasalto, ForceMode2D.Force);
            nsaltos = nsaltos + 1;
            agentAnimator.SetBool("Ground", false);
            DisableS(stiempo);
        }
    }

    /************ GOLPE NORMAL ************/
    private void Punch()
    {
        agentAnimator.SetBool("GolpeD", true);
        CancelInvoke("fpunch");
        Invoke("fpunch", td);
    }

    /************ GOLPE FUERTE ************/
    private void PunchF()
    {
        agentAnimator.SetBool("GolpeF", true);
        CancelInvoke("fpunchf");
        Invoke("fpunchf", tf);
    }

    /************ ESPECIAL ************/
    private void PunchE()
    {
        transform.localScale = new Vector3(1.2f, 1f, 1f);
        agentAnimator.SetBool("GolpeE", true);
        CancelInvoke("fpunche");
        Invoke("fpunche", te);
    }


    /************ ACTIVAR Y DESACTIVAR TIEMPO ENTRE SALTOS ************/
    void DisableS(float t)
    {
        canJump = false;
        CancelInvoke("EnableS");
        Invoke("EnableS", t);
    }
    void EnableS()
    {
        canJump = true;
    }


    /// @brief Maneja las colisiones con el suelo y las paredes.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" || collision.collider.tag == "Pared")
        {
            nsaltos = 0;
            if (collision.collider.tag == "Pared")
            {
                rb.gravityScale = gpared;
                pared = true;
            }
        }
    }

    /// @brief Maneja la salida de colisión con una pared.
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Pared")
        {
            rb.gravityScale = gravity;
            pared = false;
        }
    }

    public void DoggeGolpeado() {

        damaged = true;
        HandleGotHitPenalty();
    }

    /// @brief Recompensas y penalizaciones.
    /************ RECOMPENSAS ************/
    public void HandleHitEnemyReward()
    {
        // Si golpeamos al enemigo
        SetReward(200f);
    }

    public void HandleKillEnemyReward()
    {
        // Si tiramos al enemigo del campo de batalla
        SetReward(50f);
    }

    public void HandleWinConditionReward()
    {
        // Si ganamos el enfrentamiento
        SetReward(100f);
        EndEpisode();
    }

    /************ CASTIGOS ************/
    public void HandleGotHitPenalty()
    {
        // Si el enemigo nos golpea (si disminuye nuestra vida)
        SetReward(-10f);
    }

    public void HandleDeadPenalty()
    {
        // Si tiramos al enemigo del campo de batalla
        SetReward(-50f);
    }

    public void HandleLostConditionPenalty()
    {
        // Si perdemos el enfrentamiento
        SetReward(-100f);
        EndEpisode();
    }


    private void fpunch()
    {
        agentAnimator.SetBool("GolpeD", false);
    }
    private void fpunchf()
    {
        agentAnimator.SetBool("GolpeF", false);
    }
    private void fpunche()
    {
        agentAnimator.SetBool("GolpeE", false);
        transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
    }
}
