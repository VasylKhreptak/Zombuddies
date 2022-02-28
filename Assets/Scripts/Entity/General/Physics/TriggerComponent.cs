using UnityEngine;

public class TriggerComponent : Trigger
{
    public bool isInTrigger { get; private set; }

    [HideInInspector] public Transform affectedObject;

    protected override void OnEnter(Collider collider)
    {
        affectedObject = collider.gameObject.transform;
            
        isInTrigger = true;
        
        base.OnEnter(collider);
    }

    protected override void OnExit(Collider collider)
    {
        base.OnExit(collider);
        
        affectedObject = null;
            
        isInTrigger = false;
    }
}
