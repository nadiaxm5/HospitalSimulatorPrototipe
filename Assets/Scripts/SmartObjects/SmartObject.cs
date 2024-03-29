using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EAIType
{
    Patient = 0,
    Worker = 1,
    Both = 2
}

public class SmartObject : MonoBehaviour
{
    [SerializeField] protected string _DisplayName;
    [SerializeField] protected Transform _InteractionMarker;
    [SerializeField] protected EAIType _AIType = EAIType.Worker;
    protected List<BaseInteraction> CachedInteractions = null;

    //InteractionPoint ser� el destino que realmente se marcar� para la acci�n
    public Vector3 InteractionPoint => _InteractionMarker != null ? _InteractionMarker.position : transform.position;
    public EAIType AIType => _AIType;
    public string DisplayName => _DisplayName;

    public List<BaseInteraction> Interactions
    {
        get
        {
            if(CachedInteractions == null)
                CachedInteractions = new List<BaseInteraction>(GetComponents<BaseInteraction>());
            return CachedInteractions;
        }
    }
    
    void Start()
    {
        SmartObjectManager.Instance.RegisterSmartObject(this); //Se meten en la lista todos los SmartObjects de la escena
    }

    private void OnDestroy()
    {
        SmartObjectManager.Instance.DeregisterSmartObject(this);
    }
}
