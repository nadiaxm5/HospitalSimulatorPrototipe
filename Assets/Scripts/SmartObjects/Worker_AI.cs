using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Worker_AI : AIWithNeeds
{
    public float WorkerHappiness { get; protected set; }

    protected override void Initialise()
    {
        WorkerHappiness = initialHappinessLvl;
        CurrentEnergy = Random.Range(0.3f, 1f); //Nivel inicial de energía aleatorio para cada NPC (baja)
        CurrentStress = Random.Range(0f, 0.7f); //Nivel inicial de estrés aleatorio para cada NPC (sube)
        CurrentHunger = Random.Range(0f, 0.7f); //Nivel inicial de hambre aleatorio para cada NPC (sube)
        CurrentWork = Random.Range(0f, 0.7f); //Nivel inicial de trabajo aleatorio para cada NPC (sube)

        NPCStatesManager.Instance.RegisterWorker(this); //Se meten en la lista todos los trabajadores de la escena
    }

    void Update()
    {
        HandleInteractionOrPickNext(SmartObjectManager.Instance.WorkerObjects);
        CurrentHunger = Mathf.Clamp01(CurrentHunger + HungerIncreaseRate * Time.deltaTime);
        CurrentWork = Mathf.Clamp01(CurrentWork + WorkIncreaseRate * Time.deltaTime);
        //CurrentEnergy = Mathf.Clamp01(CurrentEnergy - EnergyDecayRate * Time.deltaTime); //La energía sube y baja por acciones
        //CurrentStress = Mathf.Clamp01(CurrentStress + StressIncreaseRate * Time.deltaTime); //El estrés sube y baja por acciones
    }
}
