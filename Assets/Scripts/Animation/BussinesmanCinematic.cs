using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class BussinesmanCinematic : MonoBehaviour
{
    [SerializeField] GameObject bussinesMan;
    [SerializeField] NavMeshAgent playerNavMesh;
    [SerializeField] GameObject player;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;
    [SerializeField] Transform waypoint;
    private bool cinematicStart;
    // Start is called before the first frame update
    void Start()
    {
        bussinesMan.SetActive(false);
        cinematicStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(cinematicStart && player.transform.position.z >= 0)
        {
            agent.destination = waypoint.position;
            playerNavMesh.enabled = false;
        }
    }

    public void StartCinematic()
    {
        cinematicStart = true;
        bussinesMan.SetActive(true);
    }
}
