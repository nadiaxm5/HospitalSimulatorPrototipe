using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker_AI : AIWithNeeds
{
    public float workerHappiness { get; protected set; }
    //[SerializeField] UnityEngine.UI.Slider HappinessDisplay; Para mostrar

    private void Awake()
    {
        workerHappiness = initialHappinessLvl;
        currentEnergy = initialEnergyLvl = Random.Range(0.2f, 1f); //Nivel inicial de energía aleatorio para cada NPC
        //HappinessDisplay.value = currentHappiness = initialHappinessLvl; Si se muestra así, pero no en cada uno, en el stateController
    }

    void Start()
    {
        StatesController.Instance.RegisterWorker(this); //Se meten en la lista todos los trabajadores de la escena
    }

    void Update()
    {
        HandleInteractionOrPickNext(SmartObjectManager.Instance.WorkerObjects);
    }
}
