using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable] //Permite que la clase sea convertida en un formato que pueda ser almacenado o transmitido

public class InteractionStatChange
{
    public EStat TargetChange;
    public float ChangeValue;
}

public abstract class BaseInteraction : MonoBehaviour
{
    [SerializeField] protected string _DisplayName; //Visible para clase y subclases
    [SerializeField] protected float _Duration = 0f;
    [SerializeField] protected InteractionStatChange[] StatChanges;

    public string DisplayName => _DisplayName; //=> Da acceso de solo lectura, DisplayName accede a _DisplayName
    public float Duration => _Duration;

    public abstract bool CanPerform(); //Dice si se puede realizar la acción o no
    public abstract void LockInteraction(); //Para acciones que solo pueda hacer un NPC a la vez
    public abstract void Perform(MonoBehaviour performer, UnityAction<BaseInteraction> onCompleted); //Lo que hacemos al llegar al lugar de la acción
    public abstract void UnLockInteraction(); //La acción queda libre para otro NPC
    public abstract int NumCurrentUsers(); //Devuelve el número de usuarios haciendo la acción
}
