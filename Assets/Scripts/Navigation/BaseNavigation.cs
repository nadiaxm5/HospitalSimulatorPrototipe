using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseNavigation : MonoBehaviour
{
    //Clase abstracta para evitar repetir código y tener una sola interfaz compartida
    public enum EState //Estados posibles
    {
        Idle                = 0,
        FindingPath         = 1,
        FollowingPath       = 2,
        Failed_NoPathExists = 100
    }

    //Cabecera para que aparezcan en el inspector
    [Header("Path Following")]
    [SerializeField] protected float DestinationReachedThreshold = 0.25f;
    [SerializeField] protected float MaxMoveSpeed = 3f;
    [SerializeField] protected float RotationSpeed = 500f;


    public Vector3 Destination { get; private set; }
    public EState State { get; private set; } = EState.Idle; //Estado predefinido: Idle

    public bool IsFindingOrFollowingPath => State == EState.FindingPath || State == EState.FollowingPath;
    public bool IsAtDestination
    {
        get
        {
            if (State != EState.Idle)
                return false;

            Vector3 vecToDestination = Destination - transform.position;
            vecToDestination.y = 0f;

            return vecToDestination.magnitude <= DestinationReachedThreshold;
        }
    }

    void Start()
    {
        Initialise(); //Al empezar, obtener NavMeshAgent (En Navigation_NavMesh)
    }

    void Update()
    {
        if (State == EState.FindingPath)
            Update_Pathfinding();
    }

    void FixedUpdate()
    {
        if (State == EState.FollowingPath) //En FixedUpdate por las físicas
            Update_PathFollowing();
    }

    public bool SetDestination(Vector3 newDestination)
    {
        //Comprobar si el nuevo destino es el destino actual (aproximadamente)
        Vector3 destinationDelta = newDestination - Destination;
        destinationDelta.y = 0f; //Asegurar que no se mueve en vertical
        if (IsFindingOrFollowingPath && (destinationDelta.magnitude <= DestinationReachedThreshold))
            return true;

        //Comprobar si ya estábamos en el nuevo destino (aproximadamente)
        destinationDelta = newDestination - transform.position;
        destinationDelta.y = 0f;
        if (destinationDelta.magnitude <= DestinationReachedThreshold)
            return true;

        //Si no ocurre ninguna de las dos cosas, se cambia el destino actual por el nuevo
        Destination = newDestination;
        return RequestPath(); //Devuelve true mientras llama a RequestPath (En Navigation_NavMesh)
    }

    public abstract void StopMovement(); //Al detenerse se resetea la ruta (En Navigation_NavMesh)

    protected abstract void Initialise(); //Para evitar tener varios Start

    protected abstract bool RequestPath(); //Se le llama en SetDestination

    protected void OnBeganPathFinding()
    {
        State = EState.FindingPath; //Cambiar estado a buscando ruta al empezar a buscarla
    }

    protected void OnPathFound()
    {
        State = EState.FollowingPath; //Cambiar estado a siguiendo ruta al encontrar una
    }

    protected void OnFailedToFindPath()
    {
        State = EState.Failed_NoPathExists; //Cambiar estado al error de no encontar ruta
        Debug.Log("No path exists");
    }

    protected void OnReachedDestination()
    {
        State = EState.Idle; //Cambiar estado a idle una vez se llega al destino
    }

    protected abstract void Update_Pathfinding();
    protected abstract void Update_PathFollowing();
}
