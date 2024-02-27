using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EInteractionType
{
    Instantaneous = 0,
    OverTime = 1
}

public abstract class BaseInteraction : MonoBehaviour
{
    [SerializeField] protected string _DisplayName; //Visible para clase y subclases
    [SerializeField] protected EInteractionType _InteractionType = EInteractionType.Instantaneous;
    [SerializeField] protected float _Duration = 0f;

    public string DisplayName => _DisplayName; //=> Da acceso de solo lectura, DisplayName accede a _DisplayName
    public EInteractionType InteractionType => _InteractionType;
    public float Duration => _Duration;

    public abstract bool CanPerform(); //Dice si se puede realizar la acción o no
    public abstract void LockInteraction(); //Para acciones que solo pueda hacer un NPC a la vez
    public abstract void Perform(MonoBehaviour performer, UnityEvent<BaseInteraction> onCompleted = null); //Lo que hacemos al llegar al lugar de la acción
    public abstract void UnLockInteraction(); //La acción queda libre para otro NPC
}
