using CharacterSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient_AI : AIWithNeeds
{
    public float PatientHappiness { get; protected set; }

    protected override void Initialise()
    {
        PatientHappiness = initialHappinessLvl;
        CurrentEnergy = Random.Range(0.3f, 1f); //Nivel inicial de energía aleatorio para cada NPC (baja)
        CurrentStress = Random.Range(0f, 0.7f); //Nivel inicial de energía aleatorio para cada NPC (sube)
        CurrentHunger = Random.Range(0f, 0.7f); //Nivel inicial de energía aleatorio para cada NPC (sube)

        NPCStatesManager.Instance.RegisterPatient(this); //Se meten en la lista todos los pacientes de la escena
    }

    void Update()
    {
        HandleInteractionOrPickNext(SmartObjectManager.Instance.PatientObjects);
        CurrentEnergy = Mathf.Clamp01(CurrentEnergy - EnergyDecayRate * Time.deltaTime);
        CurrentStress = Mathf.Clamp01(CurrentStress + StressIncreaseRate * Time.deltaTime);
        CurrentHunger = Mathf.Clamp01(CurrentHunger + HungerIncreaseRate * Time.deltaTime);
    }
}
