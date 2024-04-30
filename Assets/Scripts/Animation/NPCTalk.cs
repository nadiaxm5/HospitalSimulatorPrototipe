using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalk : MonoBehaviour
{
    GameObject player;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if(distance < 5f)
            animator.SetBool("Talking", DialogueManager.GetInstance().dialogueIsPlaying);
    }
}
