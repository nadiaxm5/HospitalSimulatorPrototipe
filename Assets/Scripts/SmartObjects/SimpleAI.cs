using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseNavigation))]

public class SimpleAI : MonoBehaviour
{
    [SerializeField] protected float pickInteractionInterval = 2f;

    protected BaseNavigation Navigation;

    protected BaseInteraction CurrentInteraction = null;
    protected bool StartedPerforming = false;

    protected float timeUntilNextInteractionPicked = -1f;

    private void Awake()
    {
        Navigation = GetComponent<BaseNavigation>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(CurrentInteraction != null)
        {
            if(Navigation.IsAtDestination && !StartedPerforming)
            {
                StartedPerforming = true;
                CurrentInteraction.Perform(this, OnInteractionFinished);
            }
        }
        else
        {
            timeUntilNextInteractionPicked -= Time.deltaTime;

            //Tiempo para elegir una interacción
            if(timeUntilNextInteractionPicked <= 0)
            {
                timeUntilNextInteractionPicked = pickInteractionInterval;
                PickRandomInteraction();
            } 
        }
    }

    void OnInteractionFinished(BaseInteraction interaction)
    {
        interaction.UnLockInteraction();
        CurrentInteraction = null;
        Debug.Log($"Finished {interaction.DisplayName}");
    }

    void PickRandomInteraction()
    {
        //Elegir objeto aleatorio del set de objetos
        int objectIndex = Random.Range(0, SmartObjectManager.Instance.RegisteredObjects.Count);
        var selectedObject = SmartObjectManager.Instance.RegisteredObjects[objectIndex];

        //Elegir interacción aleatoria del set de interacciones
        int interactionIndex = Random.Range(0, selectedObject.Interactions.Count);
        var selectedInteraction = selectedObject.Interactions[interactionIndex];

        //Comprobar si puede realizar la interacción
        if (selectedInteraction.CanPerform())
        {
            CurrentInteraction = selectedInteraction;
            CurrentInteraction.LockInteraction();
            StartedPerforming = false;

            //Moverse al destino
            if (!Navigation.SetDestination(selectedObject.InteractionPoint))
            {
                Debug.LogError($"Could not move to {selectedObject.name}");
                CurrentInteraction = null;
            }
            else
                Debug.Log($"Going to {CurrentInteraction.DisplayName} at {selectedObject.DisplayName}");
        }
    }
}
