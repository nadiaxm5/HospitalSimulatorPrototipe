using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    private int character; 
    // Start is called before the first frame update
    void Start()
    {
        //Elige el personaje: 0 hombre, 1 mujer. Es una forma provisional luego la mejoraré
        character = ChangeScene.characterSelected;
        if (character == 0)
            Destroy(transform.GetChild(1).gameObject);
        else
            Destroy(transform.GetChild(0).gameObject);
    }

}
