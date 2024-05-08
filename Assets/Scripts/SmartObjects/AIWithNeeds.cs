using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; //Para ordenar

[RequireComponent(typeof(BaseNavigation))]

public abstract class AIWithNeeds : BaseAI
{
    [SerializeField] protected float pickInteractionInterval = 0.5f;
    [SerializeField] protected float defaultInteractionScore = 0f;
    [SerializeField] protected int interactionPickSize = 2;

    protected float timeUntilNextInteractionPicked = -1f;

    class ScoredInteraction
    {
        public SmartObject TargetObject;
        public BaseInteraction Interaction;
        public float Score;
    }

    protected void HandleInteractionOrPickNext(List<SmartObject> ObjectsByAIType)
    {
        if (CurrentInteraction != null)
        {
            if (Navigation.IsAtDestination && !StartedPerforming)
            {
                StartedPerforming = true;
                CurrentInteraction.Perform(this, OnInteractionFinished);
            }
        }
        else
        {
            timeUntilNextInteractionPicked -= Time.deltaTime;

            //Elegir una acción
            if (timeUntilNextInteractionPicked <= 0)
            {
                timeUntilNextInteractionPicked = pickInteractionInterval;
                PickBestInteraction(ObjectsByAIType); //A diferencia de SimpleAI que es random
            }
        }
    }

    float ScoreInteraction(BaseInteraction interaction)
    {
        if(interaction.StatChanges.Length == 0)
        {
            return defaultInteractionScore;
        }

        float score = 0f;

        foreach (var change in interaction.StatChanges)
        {
            score += ScoreChange(change.TargetChange, change.ValueChange);
        }

        return score;
    }

    float ScoreChange(EStat target, float amount)
    {
        float currentValue = 0f;
        switch (target)
        {
            case EStat.Fatigue: currentValue = CurrentFatigue; break;
            case EStat.Stress: currentValue = CurrentStress; break;
            case EStat.Hunger: currentValue = CurrentHunger; break;
            case EStat.Work: currentValue = CurrentWork; break;
        }

        //Si el nivel es alto, al multiplicar por amount dará un score bajo porque tendrá menos impacto
        //Si el nivel es bajo, al multiplicar por amount dará un score alto porque tendrá más impacto
        return (1f - currentValue) * amount; 
    }

    protected void PickBestInteraction(List<SmartObject> ObjectsByAIType)
    {
        //Hacemos lo que hacen algunas versiones de los sims: obtener todas las interacciones,
        //calificarlas según cuál será su impacto, y elegir una al azar entre ellas
        
        //Pasar por todos los objetos puntuando sus interacciones
        List<ScoredInteraction> unsortedInteractions = new List<ScoredInteraction>();
        foreach (var smartObject in ObjectsByAIType)
        {
            foreach (var interaction in smartObject.Interactions)
            {
                if (interaction.CanPerform())
                {
                    float score = ScoreInteraction(interaction);

                    unsortedInteractions.Add(new ScoredInteraction() { TargetObject = smartObject,
                                                                     Interaction = interaction,
                                                                     Score = score });   
                }
            }
        }

        if (unsortedInteractions.Count == 0)
            return; //Si no hay ninguna, no se puede elegir

        //Ordenar las interacciones según su puntuación y elegir aleatoriamente entre las mejores (las más bajas)
        var sortedInteractions = unsortedInteractions.OrderBy(scoredInteraction => scoredInteraction.Score).ToList();

        int maxIndex = Mathf.Min(interactionPickSize, sortedInteractions.Count);
        
        var selectedIndex = Random.Range(0, maxIndex);
        var selectedObject = sortedInteractions[selectedIndex].TargetObject;
        var selectedInteraction = sortedInteractions[selectedIndex].Interaction;

        CurrentInteraction = selectedInteraction;
        CurrentInteraction.LockInteraction();
        StartedPerforming = false;

        //Movimiento
        if (CurrentInteraction.NumCurrentUsers() >= 2) //Si es una acción de más de una persona y ya hay alguien a parte de ti
        {
            //Moverse al lado del destino
            float offsetX = 1f;
            Vector3 sideDestination = selectedObject.InteractionPoint + new Vector3(offsetX, 0, 0);
            Navigation.SetDestination(sideDestination);
            Debug.Log($"Yendo a {CurrentInteraction.DisplayName} al lado de {selectedObject.DisplayName}");
        }
        else
        {
            //Moverse al destino
            Navigation.SetDestination(selectedObject.InteractionPoint);
            Debug.Log($"Yendo a {CurrentInteraction.DisplayName} en {selectedObject.DisplayName}");
        }
    }
}
