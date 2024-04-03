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

    private bool isPlaying;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.SetBool("Moving", false);
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value){
            animator.SetBool("Moving", true);
            if (!isPlaying)
            {
                SoundFXManager.instance.PlaySoundFXClip(emergencySound, transform, 1f, true);
                isPlaying = true;
            }

            agent.destination = waypoint.position;
        }
    }
}
