using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class AnnoyingManBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject annoyingMan;
    [SerializeField] private Transform player;
    private NavMeshAgent annoyingManAgent;
    private Animator annoyingManAnimator;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        annoyingMan.SetActive(false);
        annoyingManAgent = annoyingMan.GetComponent<NavMeshAgent>();
        annoyingManAnimator = annoyingMan.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        annoyingManAnimator.SetBool("Moving", annoyingManAgent.velocity.magnitude > 0.2f);
        annoyingManAgent.destination = player.position;
        distance = Vector3.Distance(player.position, annoyingMan.transform.position);
    }

    public void ActivateEvent()
    {
        gameObject.SetActive(true);
        annoyingMan.SetActive(true);
    }
}
