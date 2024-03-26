using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCharacter : MonoBehaviour
{
    protected BaseNavigation Navigation;
    RaycastManager raycastManager;

    private void Awake()
    {
        Navigation = GetComponent<BaseNavigation>();
        raycastManager = GameObject.FindObjectOfType<RaycastManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Se mueve donde pulse el botón izquierdo del mouse
        {
            Vector3 destination = raycastManager.GetHit().point;
            Navigation.SetDestination(destination);
        }

        //if (Input.GetMouseButtonDown(1)) // Se cambia de personaje con el botón derecho del mouse
        //{
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        NavMeshAgent newAgent = hit.transform.GetComponent<NavMeshAgent>();
        //        if (newAgent != null)
        //        {
        //            agent = newAgent;
        //        }
        //    }
        //}
    }
}
