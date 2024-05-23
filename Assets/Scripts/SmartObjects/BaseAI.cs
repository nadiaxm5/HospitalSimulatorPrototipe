using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EStat //Estados que afectan a las acciones
{
    Fatigue,
    Stress,
    Hunger,
    Work
}

[RequireComponent(typeof(BaseNavigation))]

public class BaseAI : MonoBehaviour
{
    [HideInInspector] public float initialHappinessLvl = 0.8f; //Este nivel bajará por acciones, igual para todos al inicio

    [HideInInspector] public float HappinessDecayRate = 0.005f; //Varia por decisiones del jugador

    //Sube poco a poco constantemente las necesidades
    [HideInInspector] public float IncreaseRate = 0.00001f;

    public float CurrentFatigue { get; protected set; }
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

    protected virtual void OnInteractionFinished(BaseInteraction interaction)
    {
        interaction.UnLockInteraction();
        CurrentInteraction = null;
        Debug.Log($"Terminado {interaction.DisplayName}");
    }

    public void UpdateIndividualStat(EStat target, float amount)
    {
        switch (target)
        {
            case EStat.Fatigue: CurrentFatigue += amount; break;
            case EStat.Stress:  CurrentStress += amount; break;
            case EStat.Hunger:  CurrentHunger += amount; break;
            case EStat.Work:    CurrentWork += amount; break;
        }
    }

    protected virtual void Initialise()
    {
        //Para evitar tener varios Awake
    }
}
