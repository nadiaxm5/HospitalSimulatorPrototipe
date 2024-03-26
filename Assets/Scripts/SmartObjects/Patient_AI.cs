using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient_AI : SimpleAI
{
    void Update()
    {
        HandleInteractionOrPickNext(SmartObjectManager.Instance.PatientObjects);
    }
}
