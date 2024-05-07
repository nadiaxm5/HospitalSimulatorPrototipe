using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable] //Permite que la clase sea convertida en un formato que pueda ser almacenado o transmitido

public class InteractionStatChange
{
    public EStat TargetChange;
    public float ValueChange;
}

public abstract class BaseInteraction : MonoBehaviour
{
    [SerializeField] protected string _DisplayName; //Visible para clase y subclases
    [SerializeField] protected float _Duration = 0f;
    [SerializeField] protected InteractionStatChange[] StatChanges;

    public string DisplayName => _DisplayName; //=> Da acceso de solo lectura, DisplayName accede a _DisplayName
    public float Duration => _Duration; //Duración de la acción

    public abstract bool CanPerform(); //Dice si se puede realizar la acción o no

    public abstract void LockInteraction(); //Para acciones que solo pueda hacer un NPC a la vez
    
    public abstract void Perform(BaseAI performer, UnityAction<BaseInteraction> onCompleted); //Lo que hacemos al llegar al lugar de la acción
    
    public abstract void UnLockInteraction(); //La acción queda libre para otro NPC
    
    public abstract int NumCurrentUsers(); //Devuelve el número de usuarios haciendo la acción

    public void ApplyStatChanges(BaseAI performer, float proportion)
    {
        Debug.Log("Llego al apply");
        foreach (var statChange in StatChanges)
        {
            Debug.Log("Llego al foreach");
            performer.UpdateIndividualStat(statChange.TargetChange , statChange.ValueChange * proportion);
        }
    }
}
