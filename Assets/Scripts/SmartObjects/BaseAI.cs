using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EStat //Estados que afectan a las acciones
{
    Energy,
    Stress,
    Hunger,
    Work
}

[RequireComponent(typeof(BaseNavigation))]

public class BaseAI : MonoBehaviour
{
    [HideInInspector] public float initialHappinessLvl = 0.8f; //Este nivel bajará por acciones, igual para todos al inicio

    [HideInInspector] public float HappinessDecayRate = 0.005f; //Varia por decisiones del jugador

    [HideInInspector] public float HungerIncreaseRate = 0.005f; //Sube poco a poco constantemente
    [HideInInspector] public float WorkIncreaseRate = 0.005f; //Sube poco a poco constantemente
    [HideInInspector] public float HungerDecreaseRate = 0.05f; //Baja por acciones
    [HideInInspector] public float WorkDecreaseRate = 0.05f; //Baja por acciones
    [HideInInspector] public float StressVariableRate = 0.05f; //Sube y baja por acciones
    [HideInInspector] public float EnergyVariableRate = 0.05f; //Sube y baja por acciones


    public float CurrentEnergy { get; protected set; }
    public float CurrentStress { get; protected set; }
    public float CurrentHunger { get; protected set; }
    public float CurrentWork { get; protected set; }

    protected BaseNavigation Navigation;

    protected BaseInteraction CurrentInteraction = null;
    protected bool StartedPerforming = false;

    [HideInInspector] public SmartObject selectedObject;

    protected virtual void Awake()
    {
        Navigation = GetComponent<BaseNavigation>();
        Initialise();
    }

    protected virtual void Start()
    {

    }

    //protected void HandleInteractionOrPickNext(List<SmartObject> ObjectsByAIType)
    //{
    //    if (CurrentInteraction != null)
    //    {
    //        if (Navigation.IsAtDestination && !StartedPerforming)
    //        {
    //            StartedPerforming = true;
    //            CurrentInteraction.Perform(this, OnInteractionFinished);
    //        }
    //    }
    //    else
    //    {
    //        timeUntilNextInteractionPicked -= Time.deltaTime;

    //        //Elegir una acción
    //        if (timeUntilNextInteractionPicked <= 0)
    //        {
    //            timeUntilNextInteractionPicked = pickInteractionInterval;
    //            PickRandomInteraction(ObjectsByAIType);
    //        }
    //    }
    //}

    protected virtual void OnInteractionFinished(BaseInteraction interaction)
    {
        interaction.UnLockInteraction();
        CurrentInteraction = null;
        Debug.Log($"Terminado {interaction.DisplayName}");
    }

    public void UpdateIndividualStat(EStat target, float amount)
    {
        Debug.Log($"Update {target} by {amount}");
        switch (target)
        {
            case EStat.Energy: CurrentEnergy += amount; break;
            case EStat.Stress: CurrentEnergy += amount; break;
            case EStat.Hunger: CurrentHunger += amount; break;
            case EStat.Work:   CurrentWork += amount; break;
        }
    }

    protected virtual void Initialise()
    {
        //Para evitar tener varios Awake
    }
}
