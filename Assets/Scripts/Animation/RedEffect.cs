using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEffect : MonoBehaviour
{
    Animator animator;
    private bool hasTalked;
    public BarManager barManager;
    private bool isPlaying;
    private bool hasTalkedAgain;
    [SerializeField] private AudioSource emergencySound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        hasTalked = false;
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            animator.SetBool("emergency", ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value);
            if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value && !isPlaying)
            {
                emergencySound.Play();
                isPlaying = true;
            }

            if (!((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value)
            {
                if(((Ink.Runtime.IntValue)DialogueManager.GetInstance().GetVariableState("emergency_election")).value == 0)
                {
                    barManager.AddChaos(-20);
                }
                else if (((Ink.Runtime.IntValue)DialogueManager.GetInstance().GetVariableState("emergency_election")).value == 1)
                {
                    barManager.AddChaos(-20);
                    barManager.AddHappinessPatient(-20);
                }
                else if (((Ink.Runtime.IntValue)DialogueManager.GetInstance().GetVariableState("emergency_election")).value == 2)
                {
                    barManager.AddChaos(-20);
                    barManager.AddHappinessCoworkers(-20);
                }

                emergencySound.Stop();
            }

            if (!hasTalked)
            {
                barManager.AddChaos(20);
                hasTalked = true;
            }
        }
    }
}
