using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AngryManBehaviour : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    public Transform waypoint;
    private float distance;
    private bool hasTalked;
    private bool hasTalkedAgain;
    [SerializeField] TextAsset inkJSON;
    [SerializeField] AngryManCinematic angryManCinematic;
    [SerializeField] GameObject phoneMenu;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.SetBool("Moving", false);
        hasTalked = false;
        hasTalkedAgain = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value && !DialogueManager.GetInstance().dialogueIsPlaying) //Esta variable puede cambiar
        {
            animator.SetBool("Moving", agent.speed > 0.2f);
            agent.destination = waypoint.position;
            distance = Vector3.Distance(waypoint.position, transform.position);
            if(distance < 4f && !hasTalked)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                hasTalked = true;
            }
            if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("talked_with_salesman")).value && !phoneMenu.activeInHierarchy)
            {
                if (!DialogueManager.GetInstance().dialogueIsPlaying)
                {
                    StartCoroutine(KillAngryMan());
                    angryManCinematic.StartFadeToBlack();
                }
                if (!hasTalkedAgain)
                {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                    hasTalkedAgain = true;
                }
            }
        }
    }

    IEnumerator KillAngryMan()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }
}