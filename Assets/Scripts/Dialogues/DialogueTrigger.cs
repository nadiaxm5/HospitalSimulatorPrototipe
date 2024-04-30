using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    public GameObject player;
    public GameObject dialogueBox;
    public GameObject dialogueBoxSolved;
    public int needToTalk;
    private int timesTalked;
    private Navigation_NavMesh playerNavMesh;
    //public ChaosBar chaosBar;
    private bool isGoingToTalk;
    private float distance;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dialogueBoxSolved.SetActive(false);
        timesTalked = 0;
        isGoingToTalk = false;
    }

    void Update()
    {
        /*Detecta el click del mouse y empieza el dialogo si clickas sobre un interactuable,
        al clickar sobre un interactauble este muestra su linea de dialogo*/
        if (Input.GetMouseButtonDown(0) && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            isGoingToTalk = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100);
            if (Physics.Raycast(ray, out hit, 100) && hit.transform.name == transform.name)
            {
                isGoingToTalk = true;
                //playerNavMesh.SetDestination(transform.position);
            }
        }
        if(isGoingToTalk)
        {
            distance = Vector3.Distance(player.transform.position, transform.position); //Calcula la distancia con el player
            if (distance <= 4f)
            {
                isGoingToTalk = false;
                StartDialogue();
                timesTalked++;
                if (timesTalked >= needToTalk)
                {
                    dialogueBox.SetActive(false);
                    dialogueBoxSolved.SetActive(true);
                }
            }
        }
    }

    public void StartDialogue()
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }

}
