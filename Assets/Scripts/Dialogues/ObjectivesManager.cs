using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

//SIN ACABAR

public class ObjectivesManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextAsset inkJSON;
    public Story currentStory;

    public void Start()
    {
        EnterDialogueMode();
    }

    public void EnterDialogueMode()
    {
        TextAsset ink = inkJSON;
        currentStory = new Story(ink.text);
        dialogueText.text = currentStory.Continue();
    }
}
