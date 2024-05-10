using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class ProtocolMeetingCinematic : MonoBehaviour
{
    [SerializeField] private Animator animatorRedEffect;
    [SerializeField] private GameObject popup;
    [SerializeField] private TextMeshProUGUI popupText;
    [SerializeField] private NavMeshAgent playerNavMesh;
    [SerializeField] private GameObject happyPopup;
    [SerializeField] private GameObject angryPopup;
    [SerializeField] private GameObject npcsReunion;
    [SerializeField] private DialogueTrigger npcNurse;

    private bool hasStarted;
    private bool popupPoped;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        hasStarted = false;
        popupPoped = false;
        popup.SetActive(false);
        happyPopup.SetActive(false);
        angryPopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            popup.SetActive(true);
            popupText.text = "Va siendo hora de convocar una reunión para hacer un protocolo, con médicos y enfermeras. Deberás leer el orden del día y, normalmente, también las actas de la reunión anterior, pero como acabas de empezar, no es necesario.";
            Time.timeScale = 0;
            playerNavMesh.enabled = false;
            hasStarted = true;
        }

        if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value && !DialogueManager.GetInstance().dialogueIsPlaying) //Esta variable puede cambiar
        {
            animatorRedEffect.SetBool("emergency", true);
        }

        if (((Ink.Runtime.IntValue)DialogueManager.GetInstance().GetVariableState("protocol_election")).value != -1 && !DialogueManager.GetInstance().dialogueIsPlaying && !popupPoped)
        {
            if (((Ink.Runtime.IntValue)DialogueManager.GetInstance().GetVariableState("protocol_election")).value == 0)
            {
                happyPopup.SetActive(true);
            }
            else
            {
                angryPopup.SetActive(true);
            }
            StartCoroutine(StartCinematic());
            popupPoped = true;
        }
    }

    public void ActivateEvent()
    {
        gameObject.SetActive(true);
        animatorRedEffect.gameObject.SetActive(true);
        ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value = true; //Para probar
        ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("task_protocol")).value = true;
        npcNurse.ResetTimesTalked();
        npcNurse.timesTalked = 0;
    }

    public void ContinueButton()
    {
        popup.SetActive(false);
        playerNavMesh.enabled = true;
        Time.timeScale = 1;
    }

    IEnumerator StartCinematic()
    {
        yield return new WaitForSeconds(2f);
        npcsReunion.SetActive(false);
        animatorRedEffect.SetBool("emergency", false);
        popup.SetActive(true);
        if (((Ink.Runtime.IntValue)DialogueManager.GetInstance().GetVariableState("protocol_election")).value == 0)
        {
            popupText.text = "¡Buen trabajo! Tu equipo está satisfecho porque cuentas con ellos, y los pacientes también por tener citas no presenciales.";
        }
        else
        {
            popupText.text = "Tu equipo no está satisfecho porque no tienes en cuenta sus ideas. Lo puedes hacer mejor.";
        }
        gameObject.SetActive(false);
    }
}
