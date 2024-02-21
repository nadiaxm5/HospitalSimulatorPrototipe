using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    public static int characterSelected;
    
    public void SelectCharcter(int chara)
    {
        characterSelected = chara;
        SceneManager.LoadScene("StageScene");
    }
}
