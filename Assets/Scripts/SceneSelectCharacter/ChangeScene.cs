using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public static int characterSelected;
    
    public void SelectCharcter(int chara)
    {
        characterSelected = chara;
        NextScene("StageScene");
    }

    public void NextScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
