using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatesController : MonoBehaviour
{

    public static StatesController Instance { get; private set; } = null;

    public List<Patient_AI> Patients { get; private set; } = new List<Patient_AI>();
    public List<Worker_AI> Workers { get; private set; } = new List<Worker_AI>();

    private void Awake()
    {
        if (Instance != null) //Si ya hay una copia, borrarla
        {
            Debug.LogError($"Trying to create a second StatesController on {gameObject.name}");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        GetHappiness();
    }

    private void GetHappiness()
    {
        //Hacer un patients.count y un workers.count, obtener sus happiness y dividirlas por el count, devolver float
    }

    public void RegisterPatient(Patient_AI toRegister)
    {
        Patients.Add(toRegister);
    }

    public void RegisterWorker(Worker_AI toRegister)
    {
        Workers.Add(toRegister);
    }

    public void DecreaseState(float state)
    {
        state -= 1f;
        ClampState(state);
    }

    public void IncreaseState(float state)
    {
        state += 1f;
        ClampState(state);
    }

    private void ClampState(float state)
    {
        state = Mathf.Clamp(state, 0f, 100f);
    }

}
