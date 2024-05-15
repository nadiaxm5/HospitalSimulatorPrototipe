using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class SuperiorsReunionCinematic : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private Animator animatorRedEffect;
    [SerializeField] private Animator animatorFadeToBlack;
    [SerializeField] private Animator phoneAnimator;
    [SerializeField] private GameObject popup;
    [SerializeField] private GameObject callMenu;
    [SerializeField] private TextMeshProUGUI popupText;
    [SerializeField] private NavMeshAgent playerNavMesh;
    [SerializeField] private GameObject reunionNPCs;
    [SerializeField] private DialogueTrigger dialogueTrigger;
    [SerializeField] private GameObject angryPopup;
    [SerializeField] private GameObject npcsReunion;
    [SerializeField] private GameObject phoneMenu;
    private bool hasStarted;
    private bool hasTalkedPhone;
    private bool animationActive; //Odio no saber programar ahhhh

    void Start()
    {
        gameObject.SetActive(false);
        reunionNPCs.SetActive(false);
        hasStarted = false;
        hasTalkedPhone = false;
        animationActive = false;
        callMenu.SetActive(false);
    }

    void Update()
    {
        if (!hasStarted)
        {
            popup.SetActive(true);
            popupText.text = "¡Te está llamando la directora! Será mejor que contestes.";
            Time.timeScale = 0;
            playerNavMesh.enabled = false;
            hasStarted = true;
        }

        if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("talked_with_nurse_reunion_director")).value && !DialogueManager.GetInstance().dialogueIsPlaying && !hasTalkedPhone)
        {
            angryPopup.SetActive(true);
            StartCoroutine(StartCinematic());
            phoneAnimator.SetBool("Ring", true);
            callMenu.SetActive(true);
            hasTalkedPhone = true;
        }

        if(hasTalkedPhone && !DialogueManager.GetInstance().dialogueIsPlaying && !callMenu.activeSelf && !animationActive)
        {
            animatorFadeToBlack.SetBool("green", true);
            animationActive = true;
            StartCoroutine(ResetCinematic());
        }
    }

    public void ActivateEvent()
    {
        gameObject.SetActive(true);
        animatorRedEffect.gameObject.SetActive(true);
        phoneAnimator.SetBool("Ring", true);
        callMenu.SetActive(true);
    }

    public void DirectorCall()
    {
        phoneAnimator.SetBool("Ring", false);
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        if (!((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("talked_with_nurse_reunion_director")).value)
        {
            dialogueTrigger.timesTalked = 0;
            dialogueTrigger.needToTalk = 1;
            dialogueTrigger.ResetTimesTalked();
        }
        reunionNPCs.SetActive(true);
        callMenu.SetActive(false);
    }

    IEnumerator StartCinematic()
    {
        yield return new WaitForSeconds(2f);
        npcsReunion.SetActive(false);
    }

    IEnumerator ResetCinematic()
    {
        yield return new WaitForSeconds(1f);
        animatorFadeToBlack.SetBool("green", false);
    }
}
