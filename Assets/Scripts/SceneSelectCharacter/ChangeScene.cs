using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Ink.Runtime;

public class ChangeScene : MonoBehaviour
{
    private void Start()
    {

    }

    public void NextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
