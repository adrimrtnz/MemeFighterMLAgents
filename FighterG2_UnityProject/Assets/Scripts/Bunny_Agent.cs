using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using System;

public class Bunny_Agent : Agent
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private float speedFactor = 1.0f;
    [SerializeField] private float movementSpeed = 100.0f;
    
    [Header("SFX")]  public SFXScript sfx;
    [SerializeField] public Animator agentAnimator;

    [Header("Cositas de pegarse a las paredes")]
    [SerializeField] public bool pared;
    [SerializeField] public float diagonal = 1f;
    [SerializeField] public float gpared = 7.0f;

    [Header("Salto")]
    public float fuerzasalto = 4000f;
    public int nsaltos = 0;
    public int saltostotales = 2;
    private bool canJump = true;
    public float stiempo = 0.3f;
    public float timeRate = 2f;

    [Header("Golpes")]
    public float td = 0.3f;
    public float tf = 0.3f;
    public float te = 0.5f;
    public bool damaged;

    private Rigidbody2D rb;
    private float gravity;
    private int movementAction;
    private int attackAction;
    private bool lookingToTheRight = true;
    private Atributos atributos;
    private bool volando = false;
    private float velocityY = 0f;
    private float nextjumpTime = 0f;
    private float nextPuñoTime = 0f;
    private float nextPatadaTime = 0f;

    Dictionary<int, Action> movementActions = new Dictionary<int, Action>();
    Dictionary<int, Action> attackActions   = new Dictionary<int, Action>();

    /************ LISTENERS RECOMPENSAS ************/
    private float currentHealth;

    private void Awake()
    {
        atributos = GetComponent<Atributos>();
        atributos.setHP(atributos.maxHP);
        atributos.setEsp(0);

        currentHealth = atributos.getHP();

        // Mapeos de los diferentes outputs de movimiento del agente a acci�n
        movementActions.Add(0, DoNotMove);
        movementActions.Add(1, MoveRight);
        movementActions.Add(2, MoveLeft);
        movementActions.Add(3, Jump);
        //movementActions.Add(4, MovementTestFunction);

        // Mapeos de los diferentes outputs de ataque del agente a acci�n
        attackActions.Add(0, () => { /* Accion vacia: no atacar */ });
        attackActions.Add(1, Punch);
        attackActions.Add(2, PunchF);
        attackActions.Add(3, PunchE);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
    }

    private void Update()
    {
        velocityY = rb.velocity.y;
        //Poner la velocidad en positivo
        if (rb.velocity.y < 0)
        {
            velocityY = velocityY * -1;
        }

        if (velocityY > 0.1f)
        {

            agentAnimator.SetBool("volando", true);
        }
        else
        {
            agentAnimator.SetBool("volando", false);
        }

    }

    public override void OnEpisodeBegin()
    {
        // Que hacer cuando se empieza el juego o se llama a EndEpisode()

        // Reset posicion, salud y vidas
        transform.position = new Vector3(-15.9f, 17.6f, 0f);
        atributos.setHP(atributos.maxHP);
        atributos.setEsp(0);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Saber donde estoy
        sensor.AddObservation(transform.position);

        // Saber donde esta mi enemigo
        sensor.AddObservation(enemy.transform.position);

        // Saber cuantos saltos puedo hacer
        sensor.AddObservation(saltostotales);

        // Saber el conteo de saltos actuales
        sensor.AddObservation(nsaltos);

        // Saber si puedo saltar
        sensor.AddObservation(canJump);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        Debug.Log("ACTIONNNN");

        movementAction = actions.DiscreteActions[0];
        attackAction   = actions.DiscreteActions[1];

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
        agentAnimator.SetBool("correr", false);
    }

    private void MoveLeft()
    {
        agentAnimator.SetBool("correr", true);
        Debug.Log("Moviendo a la Izquierda");
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
        agentAnimator.SetBool("correr", true);
        Debug.Log("Moviendo a la Derecha");
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
        Debug.Log("Moviendo Salto");
        if (Time.time >= nextjumpTime)
        {
            if (velocityY <= 0.1f)
            {
                agentAnimator.SetTrigger("saltar");

                nextjumpTime = Time.time + 1f / timeRate;
            }
        }
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
            DisableS(stiempo);
        }
    }

    /************ GOLPE NORMAL ************/
    private void Punch()
    {
        Debug.Log("Ataque PUNCH");
        //Animación patada 
        if (Time.time >= nextPatadaTime)
        {
            if (velocityY <= 0.1f)
            {
                agentAnimator.SetTrigger("patada");

                nextPatadaTime = Time.time + 1f / timeRate;
            }
        }
    }

    /************ GOLPE FUERTE ************/
    private void PunchF()
    {
        Debug.Log("Ataque PUNCHF");
        if (Time.time >= nextPuñoTime)
        {
            if (velocityY <= 0.1f)
            {
                agentAnimator.SetTrigger("Puño");

                nextPuñoTime = Time.time + 1f / timeRate;
            }
        }
    }

    /************ ESPECIAL ************/
    private void PunchE()
    {
        Debug.Log("Ataque COMUNISMO");
        //Animación comunismo 
        agentAnimator.SetTrigger("especial");
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

 
    /************ DETECTA COLISIONES ************/
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
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Pared")
        {
            rb.gravityScale = gravity;
            pared = false;
        }
    }

    public void BunnyGolpeado()
    {
        agentAnimator.SetTrigger("golpeado");
        HandleGotHitPenalty();
    }


    /************************ HANLDERS DE EVENTOS Y SISTEMA DE RECOMPENSAS ************************/

    /************ RECOMPENSAS ************/
    public void HandleHitEnemyReward()
    {
        // Si golpeamos al enemigo
        SetReward(10f);
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
}
