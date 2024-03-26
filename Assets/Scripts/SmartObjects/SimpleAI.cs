using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseNavigation))]

public abstract class SimpleAI : MonoBehaviour
{
    [SerializeField] protected float pickInteractionInterval = 1f;

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

            //Elegir una acci�n
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
        Debug.Log($"Finished {interaction.DisplayName}");
    }

    protected void PickRandomInteraction(List<SmartObject> ObjectsByAIType)
    {
        //Elegir objeto aleatorio del set de objetos
        int objectIndex = Random.Range(0, ObjectsByAIType.Count);
        selectedObject = ObjectsByAIType[objectIndex];

        //Elegir interacci�n aleatoria del set de interacciones del objeto seleccionado
        int interactionIndex = Random.Range(0, selectedObject.Interactions.Count);
        Debug.Log($"En objeto {selectedObject.DisplayName} hay {selectedObject.Interactions.Count} interacciones");
        var selectedInteraction = selectedObject.Interactions[interactionIndex];

        //Comprobar si puede realizar la interacci�n
        if (selectedInteraction.CanPerform())
        {
            CurrentInteraction = selectedInteraction;
            CurrentInteraction.LockInteraction();
            StartedPerforming = false;

            if(CurrentInteraction.NumCurrentUsers() > 1) //Si es una acci�n de m�s de una persona y ya hay alguien a parte de ti
            {
                //Moverse al lado del destino
                float offsetX = 1f;
                Vector3 sideDestination = selectedObject.InteractionPoint + new Vector3(offsetX, 0, 0);
                Navigation.SetDestination(sideDestination);
                Debug.Log($"Going to {CurrentInteraction.DisplayName} at the side of {selectedObject.DisplayName}");
            }
            else
            {
                //Moverse al destino
                Navigation.SetDestination(selectedObject.InteractionPoint);
                Debug.Log($"Going to {CurrentInteraction.DisplayName} at {selectedObject.DisplayName}");
            }
        }
    }
}
