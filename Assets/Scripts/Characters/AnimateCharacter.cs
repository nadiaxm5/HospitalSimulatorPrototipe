using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimateCharacter : MonoBehaviour
{
    [SerializeField] Animator animator;
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        animator.SetBool("Moving", false);
    }

    private void Update()
    {
        animator.SetBool("Moving", agent.velocity.magnitude >0.1f); // Se mueve
    }
}
