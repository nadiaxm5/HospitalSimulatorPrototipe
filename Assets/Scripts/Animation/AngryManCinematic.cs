using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryManCinematic : MonoBehaviour
{
    [SerializeField] private GameObject nurseReunion;
    [SerializeField] private GameObject angryMan;
    [SerializeField] private Animator animatorRedEffect;
    // Start is called before the first frame update
    void Start()
    {
        angryMan.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("talked_with_nurse_reunion")).value && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            StartCoroutine(StartCinematic());
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
}
