using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartObjectManager : MonoBehaviour
{
    public static SmartObjectManager Instance { get; private set; } = null;

    public List<SmartObject> RegisteredObjects { get; private set; } = new List<SmartObject>();

    private void Awake()
    {
        if (Instance != null) //Si ya hay una copia, borrarla
        {
            Debug.LogError($"Trying to create a second ManagerSmartObject on {gameObject.name}");
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void RegisterSmartObject(SmartObject toRegister)
    {
        RegisteredObjects.Add(toRegister);
    }

    public void DeregisterSmartObject(SmartObject toDeregister)
    {
        RegisteredObjects.Remove(toDeregister);
    }
}
