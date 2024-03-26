using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Navigation_NavMesh : BaseNavigation
{
    NavMeshAgent LinkedAgent;
    SimpleAI LinkedAI; //Para los NPCs

    protected override void Initialise()
    {
        LinkedAgent = GetComponent<NavMeshAgent>();
        LinkedAI = GetComponent<SimpleAI>();
    }

    protected override bool RequestPath()
    {
        LinkedAgent.speed = MaxMoveSpeed;
        LinkedAgent.angularSpeed = RotationSpeed;
        LinkedAgent.stoppingDistance = DestinationReachedThreshold;

        LinkedAgent.SetDestination(Destination); //Ir hasta el destino

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
        {
            OnReachedDestination();
        }

        //Si un NPC tiene una ruta y esté cerca del destino, se gira hacia él
        else if (LinkedAI != null && LinkedAgent.hasPath && LinkedAgent.remainingDistance <= LinkedAgent.stoppingDistance + 3f)
        {
            RotateToInteraction(LinkedAI.selectedObject.transform);
            Debug.Log($"Rotating to {LinkedAI.selectedObject.DisplayName} at {LinkedAI.selectedObject.transform.position}");
        }
    }

    public override void StopMovement()
    {
        LinkedAgent.ResetPath();
    }

    public override void RotateToInteraction(Transform target)
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, RotationSpeed * Time.deltaTime);
    }
}
