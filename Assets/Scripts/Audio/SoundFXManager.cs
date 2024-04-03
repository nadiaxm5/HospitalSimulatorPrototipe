using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//https://www.youtube.com/watch?v=DU7cgVsU2rM

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    [SerializeField] private AudioSource soundFXObject;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {
        //Spawnear el GameObject
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        //Asignar el AudioClip
        audioSource.clip = audioClip;

        //Asignar el volumen
        audioSource.volume = volume;

        //Reproducir el sonido
        audioSource.Play();

        //Duracion del sonido
        float clipLength = audioSource.clip.length;

        //Destruir el Gameobject despues
        Destroy(audioSource.gameObject, clipLength);
    }

}


