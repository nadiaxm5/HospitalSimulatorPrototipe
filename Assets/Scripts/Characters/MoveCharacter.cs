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
        if (Input.GetMouseButtonDown(0) /*&& !raycastManager.GetHit().transform.CompareTag("Clickable")*/) // Se mueve donde pulse el botón izquierdo del mouse
        {
            Vector3 destination = raycastManager.GetHit().point;
            Navigation.SetDestination(destination);
            Debug.Log("Objeto:" + raycastManager.GetHit().transform.name);
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
