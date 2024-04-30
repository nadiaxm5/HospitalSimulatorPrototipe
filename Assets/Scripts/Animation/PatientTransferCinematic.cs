using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatientTransferCinematic : MonoBehaviour
{
    [SerializeField] Animator animatorRedEffect;
    [SerializeField] GameObject nurse;
    [SerializeField] Transform player;
    [SerializeField] TextAsset inkJSON;
    private NavMeshAgent nurseAgent;
    private Animator nurseAnimator;
    private float distance;
    private bool hasTalked;
    void Start()
    {
        gameObject.SetActive(false);
        nurseAgent = nurse.GetComponent<NavMeshAgent>();
        nurseAnimator = nurse.GetComponent<Animator>();
        hasTalked = false;
        nurse.SetActive(false);

    }

    void Update()
    {
        if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value && !DialogueManager.GetInstance().dialogueIsPlaying) //Esta variable puede cambiar
        {
            nurseAnimator.SetBool("Moving", nurseAgent.speed > 0.2f);
            nurseAgent.destination = player.position;
            distance = Vector3.Distance(player.position, transform.position);
            if (distance < 4f && !hasTalked)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                hasTalked = true;
            }
        }
    }

    public void ActivateEvent()
    {
        gameObject.SetActive(true);
        nurse.SetActive(true);
        animatorRedEffect.gameObject.SetActive(true);
        ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value = true; //Para probar
    }
}
