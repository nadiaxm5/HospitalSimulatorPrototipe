using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimateCharacter : MonoBehaviour
{
    private Animator animator;
    NavMeshAgent agent;

    private void Awake()
    {
        if (gameObject.CompareTag("Player"))
            animator = transform.GetChild(ChangeScene.characterSelected).GetComponent<Animator>(); //Elige el animator del personaje
        else
            animator = transform.GetChild(0).GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        animator.SetBool("Moving", false);
    }

    private void Update()
    {
        animator.SetBool("Moving", agent.velocity.magnitude >0.1f); // Se mueve
    }
}
