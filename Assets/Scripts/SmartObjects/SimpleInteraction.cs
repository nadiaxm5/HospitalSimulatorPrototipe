using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleInteraction : BaseInteraction
{
    [SerializeField] protected int MaxSimultaneousUsers = 1;

    protected int NumCurrentUsers = 0;

    public override bool CanPerform()
    {
        return NumCurrentUsers < MaxSimultaneousUsers;
    }

    public override void LockInteraction()
    {
        ++NumCurrentUsers;
        if(NumCurrentUsers > MaxSimultaneousUsers)
        {
            Debug.LogError($"Too many users have locked this interaction: {_DisplayName}");
        }
    }

    public override void Perform(MonoBehaviour performer, UnityEvent<BaseInteraction> onCompleted = null)
    {
        if(NumCurrentUsers <= 0)
        {
            Debug.LogError($"Trying to perform an interaction when there are no users: {_DisplayName}");
            return;
        }

        //Comprobar tipo de interacción
        if(InteractionType == EInteractionType.Instantaneous)
        {
            if(onCompleted != null)
                onCompleted.Invoke(this);
        }

        else if(InteractionType == EInteractionType.OverTime)
        {
            //Video en 25:00
        }
    }

    public override void UnLockInteraction()
    {
        if(NumCurrentUsers <= 0)
        {
            Debug.LogError($"Trying to unlock an already unlocked interaction: {_DisplayName}");
        }
        --NumCurrentUsers;
    }
}
