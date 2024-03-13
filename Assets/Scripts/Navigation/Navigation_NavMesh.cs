using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Navigation_NavMesh : BaseNavigation
{
    NavMeshAgent LinkedAgent;

    protected override void Initialise()
    {
        LinkedAgent = GetComponent<NavMeshAgent>();
    }

    protected override bool RequestPath()
    {
        LinkedAgent.speed = MaxMoveSpeed;
        LinkedAgent.angularSpeed = RotationSpeed;
        LinkedAgent.stoppingDistance = DestinationReachedThreshold;

        LinkedAgent.SetDestination(Destination);
        
        OnBeganPathFinding();

        return true;
    }

    protected override void Update_Pathfinding()
    {
        //Si no tiene ruta pendiente, comprobar si es por haberla encontrado o por no haber podido
        if (!LinkedAgent.pathPending)
        {           
            if (LinkedAgent.pathStatus == NavMeshPathStatus.PathComplete)
                OnPathFound();
            else
                OnFailedToFindPath();
        }
    }

    protected override void Update_PathFollowing()
    {
        //Si tenemos una ruta y estamos en el destino, se cambia el estado a Idle
        if (LinkedAgent.hasPath && LinkedAgent.remainingDistance <= LinkedAgent.stoppingDistance)
            OnReachedDestination();
    }

    public override void StopMovement()
    {
        LinkedAgent.ResetPath();
    }
}
