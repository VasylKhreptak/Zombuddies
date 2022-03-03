using UnityEngine;

public class CollisionComponent : CollisionDetector
{
    public bool isObjectStaying { get; private set; }

    public GameObject stayingObject;

    protected override void OnEnter(Collision collision)
    {
        isObjectStaying = true;
        stayingObject = collision.gameObject;
        
        base.OnEnter(collision);
    }
    
    protected override void OnExit(Collision collision)
    {
        isObjectStaying = false;
        stayingObject = null;
        
        base.OnExit(collision);
    }
}
