using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleInteraction : BaseInteraction
{
    protected class PerformerInfo
    {
        public float ElapseTime;
        public UnityAction<BaseInteraction> OnCompleted;
    }

    [SerializeField] protected int MaxSimultaneousUsers = 1;

    protected int numCurrentUsers = 0;
    protected List<PerformerInfo> CurrentPerformers = new List<PerformerInfo>();

    public override bool CanPerform()
    {
        return numCurrentUsers < MaxSimultaneousUsers;
    }

    public override int NumCurrentUsers()
    {
        return numCurrentUsers;
    }

    public override void LockInteraction()
    {
        ++numCurrentUsers;
        if(numCurrentUsers > MaxSimultaneousUsers)
        {
            Debug.LogError($"Demasiados usuarios han bloqueado esta interacci�n: {_DisplayName}");
        }
    }

    public override void Perform(MonoBehaviour performer, UnityAction<BaseInteraction> onCompleted)
    {
        if(numCurrentUsers <= 0)
        {
            Debug.LogError($"Intentando realizar una interacci�n cuando no hay usuarios: {_DisplayName}");
            return;
        }

        CurrentPerformers.Add(new PerformerInfo() { ElapseTime = 0, OnCompleted = onCompleted });
    }

    public override void UnLockInteraction()
    {
        if(numCurrentUsers <= 0)
        {
            Debug.LogError($"Intentando desbloquear una interacci�n ya desbloqueada: {_DisplayName}");
        }
        --numCurrentUsers;
    }

    protected virtual void Update() //Virtual para que una subclase pueda tener su propia implementaci�n
    {
        //Actualizar cualquier current performer
        for(int i = CurrentPerformers.Count - 1; i >= 0; i--)
        {
            PerformerInfo performer = CurrentPerformers[i];
            performer.ElapseTime += Time.deltaTime;

            //Comprobar si la interacci�n se ha completado
            if(performer.ElapseTime >= _Duration)
            {
                performer.OnCompleted.Invoke(this);
                CurrentPerformers.RemoveAt(i);
            }
        }
    }
}
