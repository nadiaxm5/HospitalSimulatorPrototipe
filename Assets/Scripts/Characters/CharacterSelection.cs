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
        StartCoroutine(StartGame()); //Hago una corutina de 0.1 segundos ya que las variables de Ink no cargan inmediatamente, con este lapso de 0.1 segundos si que cargan correctamente
    }

    private void Start()
    {
        ((Ink.Runtime.IntValue)DialogueManager.GetInstance().GetVariableState("personaje")).value = character;
    }

    IEnumerator StartGame()
    {
        //Al elegir un personaje de la pantalla de selección de personaje el juego destruirá el/los personaje(s) no seleccionado(s)
        yield return new WaitForSeconds(0.1f);
        character = ((Ink.Runtime.IntValue)DialogueManager.GetInstance().GetVariableState("personaje")).value; 
        Debug.Log("El avatar elegido es: " + ((Ink.Runtime.IntValue)DialogueManager.GetInstance().GetVariableState("personaje")).value);
        //Este código está así por si se añade un tercer personaje o más
        if (character == 0)
            Destroy(transform.GetChild(1).gameObject);
        else
            Destroy(transform.GetChild(0).gameObject);
    }

}
