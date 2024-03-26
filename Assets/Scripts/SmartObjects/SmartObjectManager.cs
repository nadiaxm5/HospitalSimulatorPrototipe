using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartObjectManager : MonoBehaviour
{
    public static SmartObjectManager Instance { get; private set; } = null;

    public List<SmartObject> RegisteredObjects { get; private set; } = new List<SmartObject>();
    public List<SmartObject> WorkerObjects = new List<SmartObject>();
    public List<SmartObject> PatientObjects = new List<SmartObject>();

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

    private void Start()
    {
        DivideByAIType();
    }

    public void DivideByAIType() //Hacer dos listas según tipo de objeto
    {
        for (int i = 0; i < RegisteredObjects.Count; i++)
        {
            if (RegisteredObjects[i].AIType == EAIType.Worker)
                WorkerObjects.Add(RegisteredObjects[i]);
            else if (RegisteredObjects[i].AIType == EAIType.Patient)
                PatientObjects.Add(RegisteredObjects[i]);
            else
            {
                WorkerObjects.Add(RegisteredObjects[i]);
                PatientObjects.Add(RegisteredObjects[i]);
            }
        }
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
