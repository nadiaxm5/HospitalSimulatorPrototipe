using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseAvatar : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private void Start()
    {
        StartCoroutine(StartDialogue());
    }
    private void Update()
    {
        //if (Input.GetMouseButtonDown(0) && !DialogueManager.GetInstance().dialogueIsPlaying)
            
    }

    IEnumerator StartDialogue()
    {
        yield return new WaitForSeconds(0.01f);
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }
}
