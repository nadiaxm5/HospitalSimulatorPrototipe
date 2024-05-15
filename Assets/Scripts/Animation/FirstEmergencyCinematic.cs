using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;

public class FirstEmergencyCinematic : MonoBehaviour
{
    //Primer evento del juego 
    [SerializeField] private AudioSource emergencySound;
    [SerializeField] private GameObject redEffect;
    [SerializeField] private GameObject fadeToBlack;
    [SerializeField] private TextMeshProUGUI textFadeToBlack;
    [SerializeField] private NavMeshAgent playerNavMesh;
    [SerializeField] private GameObject[] npcs;
    [SerializeField] private BussinesmanCinematic bussinesmanCinematic;
    [SerializeField] private GameObject acceptButton;
    [SerializeField] private GameObject writeButton;
    private Animator animatorRedEffect;
    private Animator animatorFadeToBlack;
    private bool hasTalked;
    public BarManager barManager;
    private bool isPlaying;
    private bool hasTalkedAgain;
    private bool emergencyFinish;
    private bool nextCinematicStart;

    void Start()
    {
        animatorRedEffect = redEffect.GetComponent<Animator>();
        animatorFadeToBlack = fadeToBlack.GetComponent<Animator>();
        hasTalked = false;
        isPlaying = false;
        hasTalkedAgain = false;
        emergencyFinish = false;
        nextCinematicStart = false;
        acceptButton.SetActive(false);
        writeButton.SetActive(false);
    }

    void Update()
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            animatorRedEffect.SetBool("emergency", ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value);
            animatorFadeToBlack.SetBool("fade", emergencyFinish);
            playerNavMesh.enabled = !emergencyFinish;

            if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value && !isPlaying)
            {
                emergencySound.Play();
                isPlaying = true;
            }

            if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency_ended")).value && !hasTalkedAgain)
            {
                if(((Ink.Runtime.IntValue)DialogueManager.GetInstance().GetVariableState("emergency_election")).value == 0)
                {
                    barManager.AddChaos(-20);
                    textFadeToBlack.text = "Tus acciones tienen consecuencias. Has reducido el caos del hospital sin afectar a la felicidad de los pacientes o del equipo. ¡Enhorabuena!";
                }
                else if (((Ink.Runtime.IntValue)DialogueManager.GetInstance().GetVariableState("emergency_election")).value == 1)
                {
                    barManager.AddChaos(-20);
                    barManager.AddHappinessPatient(-10);
                    textFadeToBlack.text = "Tus acciones tienen consecuencias. Has reducido el caos del hospital, pero has afectado a la felicidad de los pacientes.";
                }
                else if (((Ink.Runtime.IntValue)DialogueManager.GetInstance().GetVariableState("emergency_election")).value == 2)
                {
                    barManager.AddChaos(-20);
                    barManager.AddHappinessCoworkers(-10);
                    textFadeToBlack.text = "Tus acciones tienen consecuencias. Has reducido el caos del hospital, pero has afectado a la felicidad del equipo.";
                }
                acceptButton.SetActive(true);
                hasTalkedAgain = true;
                emergencyFinish = true;
                emergencySound.Stop();
            }

            if (!hasTalked)
            {
                barManager.AddChaos(20);
                hasTalked = true;
            }
        }
    }

    public void AcceptButton()
    {
        emergencyFinish = false;
        animatorFadeToBlack.SetBool("fade", false);
        for (int i = 0; i < npcs.Length; i++)
        {
            npcs[i].SetActive(false);
        }
        if (!nextCinematicStart) //Estoy harto de poner tantos bools pero no se me ocurre nada más
        {
            bussinesmanCinematic.StartCinematic();
            nextCinematicStart = true;
        }
        acceptButton.SetActive(false);
        playerNavMesh.enabled = true;
        gameObject.SetActive(false); //Se acaba la cinematica y nunca vuelve a aparecer
    }
}
