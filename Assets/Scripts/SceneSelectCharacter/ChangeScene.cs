using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ink.Runtime;

public class ChangeScene : MonoBehaviour
{
    public void NextScene(string scene)
    {
        SceneManager.LoadScene(scene);
        GlobalVariables.fromMainMenu = false;
    }

    public void SelectAvatar(int n)
    {
        ((Ink.Runtime.IntValue)DialogueManager.GetInstance().GetVariableState("personaje")).value = n;
        GlobalVariables.fromMainMenu = true;
        SceneManager.LoadScene("NewHospital");
    }
}
