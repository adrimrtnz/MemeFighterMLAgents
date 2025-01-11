using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using System;
using System.Runtime.CompilerServices;

public class Bunny_Agent : Agent
{
    [SerializeField] private GameObject enemy;

    int movementAction;
    int attackAction;

    Dictionary<int, Action> movementActions = new Dictionary<int, Action>();
    Dictionary<int, Action> attackActions   = new Dictionary<int, Action>();

    private void Awake()
    {
        // Mapeos de los diferentes outputs de movimiento del agente a acci�n
        movementActions.Add(0, () => { /* Acci�n vac�a: no moverse */ });
        movementActions.Add(1, MovementTestFunction);
        movementActions.Add(2, MovementTestFunction);
        movementActions.Add(3, MovementTestFunction);
        movementActions.Add(4, MovementTestFunction);

        // Mapeos de los diferentes outputs de ataque del agente a acci�n
        attackActions.Add(0, () => { /* Acci�n vac�a: no atacar */ });
        attackActions.Add(1, MovementTestFunction);
        attackActions.Add(2, MovementTestFunction);
        attackActions.Add(3, MovementTestFunction);
    }

    public override void OnEpisodeBegin()
    {
        // Que hacer cuando se empieza el juego o se llama a EndEpisode()

        // Reset posici�n, salud y vidas
        transform.position = new Vector3(-15.9f, 17.6f, 0f);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Saber d�nde estoy
        sensor.AddObservation(transform.position);

        // Saber d�nde esta mi enemigo
        sensor.AddObservation(enemy.transform.position);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        movementAction = actions.DiscreteActions[0];
        attackAction   = actions.DiscreteActions[1];
        Debug.Log("Movement choice: " + movementAction + " | Attack choice: " + movementAction);

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

    private void MovementTestFunction()
    {
        Debug.Log("Esto seria una funcion de movimiento o de ataque.");
    }


    /** 
     A�adir triggers de condiciones y recompensas, por ejemplo (los valores no son finales):

     Si el enemigo nos golpea (si disminuye nuestra vida)
        SetReward(-10f);

     Si golpeamos al enemigo (hacemos disminuir su vida)
        SetReward(1f);

     Si tiramos al enemigo del campo de batalla
        SetReward(10f);

     Si ganamos el enfrentamiento
        SetReward(100f);
        EndEpisode();

     Si perdemos el enfrentamiento
        SetReward(-100f);
        EndEpisode();
     */
}
