using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraseCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (((Ink.Runtime.BoolValue)DialogueManager.GetInstance().GetVariableState("talked_with_recepcionist")).value)
        {
            gameObject.SetActive(false);
        }
    }
}
