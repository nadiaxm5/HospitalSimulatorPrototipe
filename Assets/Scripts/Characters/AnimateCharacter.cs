using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimateCharacter : MonoBehaviour
{
    [SerializeField] Animator animator;
    NavMeshAgent agent;
    float playerSpeed;
    AudioSource walkSound;

    private void Awake()
    {
        agent = GetComponentInParent<NavMeshAgent>();
        animator.SetBool("Moving", false);
        playerSpeed = GetComponentInParent<NavMeshAgent>().speed;
        walkSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        animator.SetBool("Moving", agent.velocity.magnitude >0.1f); // Se mueve
        walkSound.enabled = agent.velocity.magnitude > 0.1f;
        if (DialogueManager.GetInstance().dialogueIsPlaying)
            GetComponentInParent<NavMeshAgent>().speed = 0;
        else
            GetComponentInParent<NavMeshAgent>().speed = playerSpeed;
        animator.SetBool("Talking", DialogueManager.GetInstance().dialogueIsPlaying);
    }
}
