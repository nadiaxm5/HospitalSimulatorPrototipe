using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseNavigation))]

public abstract class AIWithNeeds : BaseAI
{
    [SerializeField] protected float pickInteractionInterval = 0.5f;

    protected override void Start()
    {
        base.Start();
    }
}
