using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class PatientTransferCinematic : MonoBehaviour
{
    [SerializeField] private Animator animatorRedEffect;
    [SerializeField] private GameObject nurse;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject phone;
    [SerializeField] private GameObject phoneMenu;
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private GameObject buttonNurse1;
    [SerializeField] private GameObject buttonNurse2;
    [SerializeField] private GameObject buttonNurse3;
    [SerializeField] private GameObject fadeToBlack;
    [SerializeField] private TextMeshProUGUI textFadeToBlack;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private NavMeshAgent playerNavMesh;
    private NavMeshAgent nurseAgent;
    private Animator nurseAnimator;
    private float distance;
    private bool hasTalked;
    private Animator animatorFadeToBlack;
    void Start()
    {
        gameObject.SetActive(false);
        nurseAgent = nurse.GetComponent<NavMeshAgent>();
        nurseAnimator = nurse.GetComponent<Animator>();
        animatorFadeToBlack = fadeToBlack.GetComponent<Animator>();
        hasTalked = false;
        nurse.SetActive(false);
        buttonNurse1.SetActive(false);
        buttonNurse2.SetActive(false);
        buttonNurse3.SetActive(false);
    }

    void Update()
    {
        if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value && !DialogueManager.GetInstance().dialogueIsPlaying) //Esta variable puede cambiar
        {
            animatorRedEffect.SetBool("emergency", true);
            nurseAnimator.SetBool("Moving", nurseAgent.velocity.magnitude > 0.2f);
            nurseAgent.destination = player.position;
            distance = Vector3.Distance(player.position, nurse.transform.position);
            if (distance < 4f && !hasTalked && !phoneMenu.activeInHierarchy)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                hasTalked = true;
            }
        }

        if (!DialogueManager.GetInstance().dialogueIsPlaying && hasTalked)
        {
            phone.SetActive(true);
            buttonNurse1.SetActive(true);
            buttonNurse2.SetActive(true);
            buttonNurse3.SetActive(true);
        }

        if (phoneMenu.activeInHierarchy)
        {
            hasTalked = false;
        }

        if (!((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            StartFadeToBlack();
        }
    }

    public void ActivateEvent()
    {
        gameObject.SetActive(true);
        nurse.SetActive(true);
        animatorRedEffect.gameObject.SetActive(true);
        ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value = true; //Para probar
    }

    public void StartFadeToBlack()
    {
        playerNavMesh.enabled = false;
        animatorRedEffect.SetBool("emergency", false);
        animatorFadeToBlack.SetBool("fade", true);
        textFadeToBlack.text = "Hay ocasiones en las que no se puede tener a todos contentos. Fuera cual fuera tu elección, la satisfacción del equipo se veía afectada.";
        continueButton.SetActive(true);
        gameObject.SetActive(false);
    }
}
