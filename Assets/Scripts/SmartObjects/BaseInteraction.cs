using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization; //Para renombrar e indicar el nombre de la versi�n anterior (FormerlySerializedAs)

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
    [SerializeField, FormerlySerializedAs("StatChanges")] protected InteractionStatChange[] _StatChanges;

    public string DisplayName => _DisplayName; //=> Da acceso de solo lectura, DisplayName accede a _DisplayName
    public float Duration => _Duration; //Duraci�n de la acci�n
    public InteractionStatChange[] StatChanges => _StatChanges;

    public abstract bool CanPerform(); //Dice si se puede realizar la acci�n o no

    public abstract void LockInteraction(); //Para acciones que solo pueda hacer un NPC a la vez
    
    public abstract void Perform(BaseAI performer, UnityAction<BaseInteraction> onCompleted); //Lo que hacemos al llegar al lugar de la acci�n
    
    public abstract void UnLockInteraction(); //La acci�n queda libre para otro NPC
    
    public abstract int NumCurrentUsers(); //Devuelve el n�mero de usuarios haciendo la acci�n

    public void ApplyStatChanges(BaseAI performer, float proportion)
    {
        foreach (var statChange in StatChanges)
        {
            performer.UpdateIndividualStat(statChange.TargetChange , statChange.ValueChange * proportion);
        }
    }
}
