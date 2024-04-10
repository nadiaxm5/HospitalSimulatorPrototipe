using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseNavigation))]

public abstract class SimpleAI : MonoBehaviour
{
    [SerializeField] protected float pickInteractionInterval = 0.5f;

    protected BaseNavigation Navigation;

    protected BaseInteraction CurrentInteraction = null;
    protected bool StartedPerforming = false;

    protected float timeUntilNextInteractionPicked = -1f;

    [HideInInspector] public SmartObject selectedObject;

    private void Awake()
    {
        Navigation = GetComponent<BaseNavigation>();
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
                PickRandomInteraction(ObjectsByAIType);
            }
        }
    }

    protected void OnInteractionFinished(BaseInteraction interaction)
    {
        interaction.UnLockInteraction();
        CurrentInteraction = null;
        Debug.Log($"Terminado {interaction.DisplayName}");
    }

    protected void PickRandomInteraction(List<SmartObject> ObjectsByAIType)
    {
        //Elegir objeto aleatorio del set de objetos
        int objectIndex = Random.Range(0, ObjectsByAIType.Count);
        selectedObject = ObjectsByAIType[objectIndex];

        //Elegir interacción aleatoria del set de interacciones del objeto seleccionado
        int interactionIndex = Random.Range(0, selectedObject.Interactions.Count);
        var selectedInteraction = selectedObject.Interactions[interactionIndex];

        //Comprobar si puede realizar la interacción
        if (selectedInteraction.CanPerform())
        {
            CurrentInteraction = selectedInteraction;
            CurrentInteraction.LockInteraction();
            StartedPerforming = false;

            if(CurrentInteraction.NumCurrentUsers() >= 2) //Si es una acción de más de una persona y ya hay alguien a parte de ti
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
}
