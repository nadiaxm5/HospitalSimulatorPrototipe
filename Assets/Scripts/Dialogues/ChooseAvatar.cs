using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseAvatar : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    void Start()
    {
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !DialogueManager.GetInstance().dialogueIsPlaying)
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }
}
