using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEffect : MonoBehaviour
{
    Animator animator;
    bool hasTalked;
    public ChaosBar chaosBar;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hasTalked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            animator.SetBool("emergency", true);
            if (!hasTalked)
            {
                chaosBar.AddChaos(20);
                hasTalked = true;
            }
        }
    }
}
