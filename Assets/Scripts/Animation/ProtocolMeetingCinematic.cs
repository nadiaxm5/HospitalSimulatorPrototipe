using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProtocolMeetingCinematic : MonoBehaviour
{
    [SerializeField] private Animator animatorRedEffect;
    [SerializeField] private GameObject popup;
    [SerializeField] private TextMeshProUGUI popupText;

    private bool hasStarted;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        hasStarted = false;
        popup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            popup.SetActive(true);
            popupText.text = "Va siendo hora de convocar una reuni�n para hacer un protocolo, con m�dicos y enfermeras. Deber�s leer el orden del d�a y, normalmente, tambi�n las actas de la reuni�n anterior, pero como acabas de empezar, no es necesario.";
            Time.timeScale = 0;
            hasStarted = true;
        }

        if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value && !DialogueManager.GetInstance().dialogueIsPlaying) //Esta variable puede cambiar
        {
            animatorRedEffect.SetBool("emergency", true);
        }
    }

    public void ActivateEvent()
    {
        gameObject.SetActive(true);
        animatorRedEffect.gameObject.SetActive(true);
        ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value = true; //Para probar
    }

    public void ContinueButton()
    {
        popup.SetActive(false);
        Time.timeScale = 1;
    }
}
