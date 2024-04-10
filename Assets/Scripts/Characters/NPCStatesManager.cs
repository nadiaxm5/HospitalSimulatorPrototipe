using CharacterSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCStatesManager : MonoBehaviour
{
    public static NPCStatesManager Instance { get; private set; } = null;

    public List<Patient_AI> Patients { get; private set; } = new List<Patient_AI>();
    public List<Worker_AI> Workers { get; private set; } = new List<Worker_AI>();

    public float globalPatientHappiness = 0f;
    public float globalWorkerHappiness = 0f;

    private void Awake()
    {
        if (Instance != null) //No hacer copias
        {
            Debug.LogError($"Intentando crear otro StatesController en {gameObject.name}");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        globalPatientHappiness = GetPatientsHappiness(Patients);
        globalWorkerHappiness = GetWorkersHappiness(Workers);
        //Mostrar en sliders del UI estas globalHappiness
    }

    private float GetPatientsHappiness(List<Patient_AI> patients)
    {
        float totalPatientHappiness = 0f;
        foreach (Patient_AI patient in patients)
        {
            totalPatientHappiness += patient.PatientHappiness;
        }
        return totalPatientHappiness /= patients.Count; //Media de la felicidad
    }

    private float GetWorkersHappiness(List<Worker_AI> workers)
    {
        float totalWorkerHappiness = 0f;
        foreach (Worker_AI worker in workers)
        {
            totalWorkerHappiness += worker.WorkerHappiness;
        }
        return totalWorkerHappiness /= workers.Count; //Media de la felicidad
    }

    public void RegisterPatient(Patient_AI toRegister)
    {
        Patients.Add(toRegister);
    }

    public void RegisterWorker(Worker_AI toRegister)
    {
        Workers.Add(toRegister);
    }
}
