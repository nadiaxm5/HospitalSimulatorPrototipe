using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMoveTo : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    public Transform waypoint;
    [SerializeField] private AudioClip emergencySound;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.SetBool("Moving", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value){
            animator.SetBool("Moving", true);
            SoundFXManager.instance.PlaySoundFXClip(emergencySound, transform, 1f);
            agent.destination = waypoint.position;
        }
    }
}
