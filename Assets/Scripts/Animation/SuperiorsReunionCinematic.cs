using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class SuperiorsReunionCinematic : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private Animator animatorRedEffect;
    [SerializeField] private Animator phoneAnimator;
    [SerializeField] private GameObject popup;
    [SerializeField] private GameObject callMenu;
    [SerializeField] private TextMeshProUGUI popupText;
    [SerializeField] private NavMeshAgent playerNavMesh;
    [SerializeField] private GameObject reunionNPCs;
    [SerializeField] private DialogueTrigger dialogueTrigger;
    [SerializeField] private GameObject angryPopup;
    [SerializeField] private GameObject npcsReunion;
    private bool hasStarted;

    void Start()
    {
        gameObject.SetActive(false);
        reunionNPCs.SetActive(false);
        hasStarted = false;
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

        if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("talked_with_nurse_reunion_director")).value && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            angryPopup.SetActive(true);
            StartCoroutine(StartCinematic());
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
        ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("talked_with_director_phone")).value = true;
        dialogueTrigger.timesTalked = 0;
        dialogueTrigger.needToTalk = 1;
        dialogueTrigger.ResetTimesTalked();
        reunionNPCs.SetActive(true);
        callMenu.SetActive(false);
    }

    IEnumerator StartCinematic()
    {
        yield return new WaitForSeconds(2f);
        npcsReunion.SetActive(false);
    }
}
