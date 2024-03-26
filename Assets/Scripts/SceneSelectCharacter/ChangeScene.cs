using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ink.Runtime;
using Ink.UnityIntegration;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private TextAsset inkJSON;

    private void Start()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
        }
        if(((Ink.Runtime.IntValue)DialogueManager.GetInstance().GetVariableState("character_is_chosen")).value != 0)
           SceneManager.LoadScene("CopyHospital");
    }
}
