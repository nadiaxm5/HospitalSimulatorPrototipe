using CharacterSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient_AI : AIWithNeeds
{
    public float PatientHappiness { get; protected set; }
    //Para verlo en el inspector
    [SerializeField] float fatigue;
    [SerializeField] float stress;
    [SerializeField] float hunger;

    protected override void Initialise()
    {
        PatientHappiness = initialHappinessLvl;
        CurrentFatigue = Random.Range(0f, 0.7f); //Nivel inicial de fatiga aleatorio para cada NPC
        CurrentStress = Random.Range(0f, 0.7f); //Nivel inicial de estrés aleatorio para cada NPC
        CurrentHunger = Random.Range(0f, 0.7f); //Nivel inicial de hambre aleatorio para cada NPC
        CurrentWork = 0f; //Los pacientes no tienen trabajo

        NPCStatesManager.Instance.RegisterPatient(this); //Se meten en la lista todos los pacientes de la escena
    }

    void Update()
    {
        HandleInteractionOrPickNext(SmartObjectManager.Instance.PatientObjects);
        
        fatigue = CurrentFatigue = Mathf.Clamp01(CurrentFatigue + IncreaseRate * Time.deltaTime); 
        stress = CurrentStress = Mathf.Clamp01(CurrentStress + IncreaseRate * Time.deltaTime); 
        hunger = CurrentHunger = Mathf.Clamp01(CurrentHunger + IncreaseRate * Time.deltaTime);
    }
}
