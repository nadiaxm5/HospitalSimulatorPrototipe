using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient_AI : AIWithNeeds
{
    public float patientHappiness { get; protected set; }
    //[SerializeField] UnityEngine.UI.Slider HappinessDisplay; Para mostrar
    
    private void Awake()
    {
        patientHappiness = initialHappinessLvl;
        currentEnergy = initialEnergyLvl = Random.Range(0.2f, 1f); //Nivel inicial de energía aleatorio para cada NPC
        //HappinessDisplay.value = currentHappiness = initialHappinessLvl; Si se muestra así, pero no en cada uno, en el stateController
    }

    void Start()
    {
        StatesController.Instance.RegisterPatient(this); //Se meten en la lista todos los pacientes de la escena
    }

    void Update()
    {
        HandleInteractionOrPickNext(SmartObjectManager.Instance.PatientObjects);
    }
}
