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
    public TMP_Text text;
    //public ChaosBar chaosBar;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dialogueBoxSolved.SetActive(false);
        timesTalked = 0;
    }

    void Update()
    {
        /*Detecta el click del mouse y empieza el dialogo si clickas sobre un interactuable,
        al clickar sobre un interactauble este muestra su linea de dialogo*/
        if (Input.GetMouseButtonDown(0) && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100);
            if (Physics.Raycast(ray, out hit, 100) && hit.transform.name == transform.name)
            {
                float distance = Vector3.Distance(player.transform.position, transform.position); //Calcula la distancia con el player
                Debug.Log("Distancia:" + distance);
                if(distance <= 4f) //Activa el dialogo solo si el jugador est� cerca
                {
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                    timesTalked++;
                    if(timesTalked >= needToTalk)
                    {
                        dialogueBox.SetActive(false);
                        dialogueBoxSolved.SetActive(true);
                    }
                    //chaosBar.SetChaos(30);
                }
                    
            }
        }
        text.text = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("current_mission")).value;
    }

}
