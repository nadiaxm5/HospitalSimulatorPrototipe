using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseMenu;

    private void Start()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        //StartCoroutine(Resuming());
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(pauseMenu.activeInHierarchy && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    //IEnumerator Resuming()
    //{
    //    float pauseTime = Time.realtimeSinceStartup + 1f;
    //    while (Time.realtimeSinceStartup < pauseTime)
    //    {
    //        yield return 0;
    //    }
    //    pauseMenu.SetActive(false);
    //    Time.timeScale = 1; 
    //}

}
