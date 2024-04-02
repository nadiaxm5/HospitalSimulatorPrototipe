using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimateCharacter : MonoBehaviour
{
    [SerializeField] Animator animator;
    NavMeshAgent agent;
    float playerSpeed;

    private void Awake()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        animator.SetBool("Moving", false);
        playerSpeed = GetComponentInParent<NavMeshAgent>().speed;
    }

    private void Update()
    {
        animator.SetBool("Moving", agent.velocity.magnitude >0.1f); // Se mueve
        if (DialogueManager.GetInstance().dialogueIsPlaying)
        {
            GetComponentInParent<NavMeshAgent>().speed = 0;
            animator.SetBool("Talking", true);
        }
        else
        {
            GetComponentInParent<NavMeshAgent>().speed = playerSpeed;
            animator.SetBool("Talking", false);
        }
    }
}
