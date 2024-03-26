using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker_AI : SimpleAI
{
    void Update()
    {
        HandleInteractionOrPickNext(SmartObjectManager.Instance.WorkerObjects);
    }
}
