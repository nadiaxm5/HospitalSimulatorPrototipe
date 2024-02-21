using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveCharacterInput : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Camera mainCam;

    private void Update()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) // Se mueve donde pulse el botón izquierdo del mouse
        {
            Physics.Raycast(ray, out hit);
            agent.destination = hit.point;
        }

        if (Input.GetMouseButtonDown(1)) // Se cambia de personaje con el botón derecho del mouse
        {
            if (Physics.Raycast(ray, out hit))
            {
                NavMeshAgent newAgent = hit.transform.GetComponent<NavMeshAgent>();
                if (newAgent != null)
                {
                    agent = newAgent;
                }
            }
        }
    }
}
