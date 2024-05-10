using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AngryManCinematic : MonoBehaviour
{
    [SerializeField] private GameObject nurseReunion;
    [SerializeField] private GameObject phoneImage;
    [SerializeField] private GameObject angryMan;
    [SerializeField] private Animator animatorRedEffect;
    [SerializeField] private GameObject callButton;
    [SerializeField] private GameObject fadeToBlack;
    [SerializeField] private TextMeshProUGUI textFadeToBlack;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject writeButton;
    [SerializeField] private GameObject happyPopup;
    private Animator animatorFadeToBlack;
    private bool isImage; //Provisional hasta que hayan más imagenes
    // Start is called before the first frame update
    void Start()
    {
        angryMan.SetActive(false);
        callButton.SetActive(false);
        happyPopup.SetActive(false);
        animatorFadeToBlack = fadeToBlack.GetComponent<Animator>();
        phoneImage.SetActive(false);
        writeButton.SetActive(false);
        isImage = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("talked_with_nurse_reunion")).value && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            happyPopup.SetActive(true);
            StartCoroutine(StartCinematic());
        }

        if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("talked_with_nurse_reunion")).value)
        {
            callButton.SetActive(true);
        }

        if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("talked_with_salesman")).value && !DialogueManager.GetInstance().dialogueIsPlaying && !isImage)
        {
            phoneImage.SetActive(true);
        }
    }

    IEnumerator StartCinematic()
    {
        yield return new WaitForSeconds(2f);
        nurseReunion.SetActive(false);
        happyPopup.SetActive(false);
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
        writeButton.SetActive(true);
        gameObject.SetActive(false);
    }

    public void WriteButton()
    {
        textFadeToBlack.text = "¡La comisión de compras ha aprobado la compra de los nuevos apósitos! Has mejorado la economía del hospital.";
        continueButton.SetActive(true);
        writeButton.SetActive(false);
    }

    public void DeleteImage()
    {
        if (phoneImage.activeInHierarchy)
        {
            phoneImage.SetActive(false);
            isImage = true;
        }
    }
}
