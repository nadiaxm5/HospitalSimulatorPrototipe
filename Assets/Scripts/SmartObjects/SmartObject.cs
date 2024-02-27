using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartObject : MonoBehaviour
{
    [SerializeField] protected string _DisplayName;
    protected List<BaseInteraction> CachedInteractions = null;

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
    // Start is called before the first frame update
    void Start()
    {
        SmartObjectManager.Instance.RegisterSmartObject(this);
    }

    private void OnDestroy()
    {
        SmartObjectManager.Instance.DeregisterSmartObject(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
