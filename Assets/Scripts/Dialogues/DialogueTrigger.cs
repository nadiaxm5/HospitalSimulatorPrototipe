using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        /*Detecta el click del mouse y empieza el dialogo si clickas sobre un interactuable,
        al clickar sobre un interactauble este muestra su linea de dialogo*/
        if (Input.GetMouseButtonDown(0) && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100) && hit.transform.name == transform.name)
            {
                float distance = Vector3.Distance(player.transform.position, transform.position); //Calcula la distancia con el player
                if(distance <= 2f) //Activa el dialogo solo si el jugador está cerca
                    DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        }
    }

}
