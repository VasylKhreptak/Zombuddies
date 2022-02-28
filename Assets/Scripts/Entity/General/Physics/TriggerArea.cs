using System.Collections.Generic;
using UnityEngine;

public class TriggerArea : Trigger                  
{
    [HideInInspector] public List<Transform> affectedObjects;

    public bool IsEmpty => affectedObjects.Count == 0;
    
    protected override void OnEnter(Collider collider)
    {
        affectedObjects.Add(collider.gameObject.transform);
        
        base.OnEnter(collider);
    }

    protected override void OnExit(Collider collider)
    {
        affectedObjects.Remove(collider.gameObject.transform);
        
        base.OnExit(collider);
    }
}
