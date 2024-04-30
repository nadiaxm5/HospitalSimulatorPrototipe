using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    private int character; 
    // Start is called before the first frame update
    void Awake()
    {
        //Elige el personaje: 0 chico, 1 chica. Es una forma provisional luego la mejoraré
        character = ((Ink.Runtime.IntValue)DialogueManager.GetInstance().GetVariableState("personaje")).value;
        Debug.Log("El avatar elegido es: " + ((Ink.Runtime.IntValue)DialogueManager.GetInstance().GetVariableState("personaje")).value);
        if (character == 0)
            Destroy(transform.GetChild(1).gameObject);
        else
            Destroy(transform.GetChild(0).gameObject);
    }

    private void Start()
    {
        ((Ink.Runtime.IntValue)DialogueManager.GetInstance().GetVariableState("personaje")).value = character;
    }

}
