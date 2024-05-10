using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class SuperiorsReunionCinematic : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private Animator animatorRedEffect;
    [SerializeField] private GameObject popup;
    [SerializeField] private GameObject callMenu;
    [SerializeField] private TextMeshProUGUI popupText;
    [SerializeField] private NavMeshAgent playerNavMesh;
    [SerializeField] private GameObject reunionNPCs;
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
    }

    public void ActivateEvent()
    {
        gameObject.SetActive(true);
        animatorRedEffect.gameObject.SetActive(true);
        callMenu.SetActive(true);
    }

    public void DirectorCall()
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        reunionNPCs.SetActive(true);
    }
}
