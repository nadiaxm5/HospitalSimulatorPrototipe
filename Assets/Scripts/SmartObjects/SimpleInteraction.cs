using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SimpleInteraction : BaseInteraction
{
    protected class PerformerInfo
    {
        public BaseAI PerformingAI;
        public float ElapsedTime;
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
            Debug.LogError($"Demasiados usuarios han bloqueado esta interacción: {_DisplayName}");
        }
    }

    public override void Perform(BaseAI performer, UnityAction<BaseInteraction> onCompleted)
    {
        if(numCurrentUsers <= 0)
        {
            Debug.LogError($"Intentando realizar una interacción cuando no hay usuarios: {_DisplayName}");
            return;
        }
        Debug.Log("Entro al Perform");
        CurrentPerformers.Add(new PerformerInfo() { PerformingAI = performer, ElapsedTime = 0, OnCompleted = onCompleted });
    }

    public override void UnLockInteraction()
    {
        if(numCurrentUsers <= 0)
        {
            Debug.LogError($"Intentando desbloquear una interacción ya desbloqueada: {_DisplayName}");
        }
        --numCurrentUsers;
    }

    protected virtual void Update() //Virtual para que una subclase pueda tener su propia implementación
    {
        Debug.Log($"Current performers: {CurrentPerformers.Count}");
        //Actualizar cualquier current performer
        for (int i = CurrentPerformers.Count - 1; i >= 0; i--)
        {
            PerformerInfo performer = CurrentPerformers[i];

            float previousElapsedTime = performer.ElapsedTime;
            performer.ElapsedTime = Mathf.Min(performer.ElapsedTime + Time.deltaTime, _Duration); //No sobrepasar duración

            Debug.Log("Llego al for");
            if (StatChanges.Length > 0) //Aplicar cambios en los estados en un porcentaje
            {
                Debug.Log("Llego al if");
                ApplyStatChanges(performer.PerformingAI, (performer.ElapsedTime - previousElapsedTime) / _Duration);
            }

            //Comprobar si la interacción se ha completado
            if(performer.ElapsedTime >= _Duration)
            {
                performer.OnCompleted.Invoke(this);
                CurrentPerformers.RemoveAt(i);
            }
        }
    }
}
