using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AngryManCinematic : MonoBehaviour
{
    [SerializeField] private GameObject nurseReunion;
    [SerializeField] private GameObject angryMan;
    [SerializeField] private Animator animatorRedEffect;
    [SerializeField] private GameObject callButton;
    [SerializeField] private GameObject fadeToBlack;
    [SerializeField] private TextMeshProUGUI textFadeToBlack;
    private Animator animatorFadeToBlack;
    // Start is called before the first frame update
    void Start()
    {
        angryMan.SetActive(false);
        callButton.SetActive(false);
        animatorFadeToBlack = fadeToBlack.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("talked_with_nurse_reunion")).value && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            StartCoroutine(StartCinematic());
        }

        if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("talked_with_nurse_reunion")).value)
        {
            callButton.SetActive(true);
        }
    }

    IEnumerator StartCinematic()
    {
        yield return new WaitForSeconds(2f);
        nurseReunion.SetActive(false);
        ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("talked_with_nurse_reunion")).value = false;
        ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value = true;
        angryMan.SetActive(true);
        animatorRedEffect.SetBool("emergency", true);
    }

    public void StartFadeToBlack()
    {
        animatorRedEffect.SetBool("emergency", false);
        animatorFadeToBlack.SetBool("fade", true);
        textFadeToBlack.text = "Has conseguido volver a tener a tus compañeros contentos, y parece ser que a los pacientes les gustan los nuevos apósitos. Ahora, es la comisión de compras la que debe aprobar esta decisión.";
    }
}
