using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RedEffect : MonoBehaviour
{
    Animator animatorRedEffect;
    Animator animatorFadeToBlack;
    private bool hasTalked;
    public BarManager barManager;
    private bool isPlaying;
    private bool hasTalkedAgain;
    [SerializeField] private AudioSource emergencySound;
    [SerializeField] private GameObject redEffect;
    [SerializeField] private Image fadeToBlack;
    [SerializeField] private TextMeshProUGUI textFadeToBlack;
    // Start is called before the first frame update
    void Start()
    {
        animatorRedEffect = redEffect.GetComponent<Animator>();
        animatorFadeToBlack = fadeToBlack.GetComponent<Animator>();
        hasTalked = false;
        isPlaying = false;
        hasTalkedAgain = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialogueManager.GetInstance().dialogueIsPlaying)
        {
            animatorRedEffect.SetBool("emergency", ((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("emergency")).value);
            animatorFadeToBlack.SetBool("fade", hasTalkedAgain);
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
                hasTalkedAgain = true;
                emergencySound.Stop();
            }

            if (!hasTalked)
            {
                barManager.AddChaos(20);
                hasTalked = true;
            }
        }
    }
}
