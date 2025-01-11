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
        // Mapeos de los diferentes outputs de movimiento del agente a acción
        movementActions.Add(0, () => { /* Acción vacía: no moverse */ });
        movementActions.Add(1, MovementTestFunction);
        movementActions.Add(2, MovementTestFunction);
        movementActions.Add(3, MovementTestFunction);
        movementActions.Add(4, MovementTestFunction);

        // Mapeos de los diferentes outputs de ataque del agente a acción
        attackActions.Add(0, () => { /* Acción vacía: no atacar */ });
        attackActions.Add(1, MovementTestFunction);
        attackActions.Add(2, MovementTestFunction);
        attackActions.Add(3, MovementTestFunction);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Saber dónde estoy
        sensor.AddObservation(transform.position);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        movementAction = actions.DiscreteActions[0];
        attackAction   = actions.DiscreteActions[1];
        Debug.Log("Movement choice: " + movementAction + " | Attack choice: " + movementAction);

        // Ejecuta movimiento (si lo hay)
        movementActions[movementAction]();

        // Ejecuta ataque (si lo hay)
        attackActions[attackAction]();
    }

    private void MovementTestFunction()
    {
        Debug.Log("Esto seria una funcion de movimiento o de ataque.");
    }
}
