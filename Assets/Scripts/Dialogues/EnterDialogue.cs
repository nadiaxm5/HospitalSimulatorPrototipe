using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDialogue : MonoBehaviour
{
    // Una funci�n publica para abrir el dialogo desde cualquier lado
    [SerializeField] private TextAsset inkJSON;

    public void DialogueStart()
    {
        DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
    }
   
}
