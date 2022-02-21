using System;
using UnityEngine;

public class CollisionComponent : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private CollisionComponentData _collisionComponentData;

    public bool isStaying { get; private set; }

    public Action<Collision> onEnter;
    public Action<Collision> onExit;

    #region MonoBehaviour

    private void OnCollisionEnter(Collision collision)
    {
        if (_collisionComponentData.LayerMask.ContainsLayer(collision.gameObject.layer))
        {
            onEnter?.Invoke(collision);
            
            isStaying = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (_collisionComponentData.LayerMask.ContainsLayer(collision.gameObject.layer))
        {
            onExit?.Invoke(collision);

            isStaying = false;
        }
    }

    #endregion
}
