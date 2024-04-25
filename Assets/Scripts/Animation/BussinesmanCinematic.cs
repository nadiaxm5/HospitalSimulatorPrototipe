using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class BussinesmanCinematic : MonoBehaviour
{
    [SerializeField] private GameObject bussinesMan;
    [SerializeField] private NavMeshAgent playerNavMesh;
    [SerializeField] private GameObject player;
    [SerializeField] private NavMeshAgent agentBussinesMan;
    [SerializeField] private Animator animatorBussinesMan;
    [SerializeField] private Transform waypoint;
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private GameObject phone;
    [SerializeField] private GameObject phoneMenu;
    [SerializeField] private GameObject nurseReunion;
    private bool cinematicStart;
    private bool hasTalked;
    // Start is called before the first frame update
    void Start()
    {
        bussinesMan.SetActive(false);
        cinematicStart = false;
        hasTalked = false;
        phone.SetActive(false);
        nurseReunion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(cinematicStart && player.transform.position.z >= 0 && !hasTalked)
        {
            agentBussinesMan.destination = waypoint.position;
            playerNavMesh.enabled = false;
        }

        if(agentBussinesMan.transform.position.z <= waypoint.position.z && !hasTalked)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            hasTalked = true;
        }

        if (!DialogueManager.GetInstance().dialogueIsPlaying && hasTalked)
        {
            //agentBussinesMan.enabled = false;
            //playerNavMesh.enabled = true;
            bussinesMan.SetActive(false);
            phone.SetActive(true);
        }
    }

    public void StartCinematic()
    {
        cinematicStart = true;
        bussinesMan.SetActive(true);
    }

    public void PressButtonCallCinematic()
    {
        nurseReunion.SetActive(true);
        phoneMenu.SetActive(false);
        playerNavMesh.enabled = true;
        Time.timeScale = 1;
        gameObject.SetActive(false); //Se acaba la cinematica y nunca vuelve a aparecer
    }
}
