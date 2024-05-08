using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Worker_AI : AIWithNeeds
{
    public float WorkerHappiness { get; protected set; }
    //Para verlo en el inspector
    [SerializeField] float fatigue;
    [SerializeField] float stress;
    [SerializeField] float hunger;
    [SerializeField] float work;

    protected override void Initialise()
    {
        WorkerHappiness = initialHappinessLvl;
        CurrentFatigue = Random.Range(0f, 0.7f); //Nivel inicial de fatiga aleatorio para cada NPC
        CurrentStress = Random.Range(0f, 0.7f); //Nivel inicial de estrés aleatorio para cada NPC
        CurrentHunger = Random.Range(0f, 0.7f); //Nivel inicial de hambre aleatorio para cada NPC
        CurrentWork = Random.Range(0f, 0.7f); //Nivel inicial de trabajo aleatorio para cada NPC

        NPCStatesManager.Instance.RegisterWorker(this); //Se meten en la lista todos los trabajadores de la escena
    }

    void Update()
    {
        HandleInteractionOrPickNext(SmartObjectManager.Instance.WorkerObjects);
        fatigue = CurrentFatigue = Mathf.Clamp01(CurrentFatigue + IncreaseRate * Time.deltaTime);
        stress = CurrentStress = Mathf.Clamp01(CurrentStress + IncreaseRate * Time.deltaTime);
        hunger = CurrentHunger = Mathf.Clamp01(CurrentHunger + IncreaseRate * Time.deltaTime);
        work = CurrentWork = Mathf.Clamp01(CurrentWork + IncreaseRate * Time.deltaTime);
    }
}
