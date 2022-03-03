using System;
using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : Trigger
{ 
    public List<Transform> affectedObjects;

    public bool IsEmpty => affectedObjects.Count == 0;

    public Action<Transform> onEnterFirst;
    public Action<Transform> onExitLast;

    protected override void OnEnter(Collider collider)
    {
        if (IsEmpty)
        {
            affectedObjects.Add(collider.gameObject.transform);

            onEnterFirst?.Invoke(collider.gameObject.transform);
            
            base.OnEnter(collider);

            return;
        }

        affectedObjects.Add(collider.gameObject.transform);

        base.OnEnter(collider);
    }

    protected override void OnExit(Collider collider)
    {
        affectedObjects.Remove(collider.gameObject.transform);

        if (IsEmpty)
        {
            onExitLast?.Invoke(collider.gameObject.transform);
        }

        base.OnExit(collider);
    }
}
