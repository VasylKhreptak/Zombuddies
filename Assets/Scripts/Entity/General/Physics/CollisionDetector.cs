using System;
using UnityEditor;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] protected CollisionDetectorData _collisionDetectorData;

    public Action<Collision> onEnter;
    public Action<Collision> onExit;

    #region MonoBehaviour

    private void OnCollisionEnter(Collision collision)
    {
        if (_collisionDetectorData.LayerMask.ContainsLayer(collision.gameObject.layer))
        {
            OnEnter(collision);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (_collisionDetectorData.LayerMask.ContainsLayer(collision.gameObject.layer))
        {
            OnExit(collision);
        }
    }

    #endregion

    protected virtual void OnEnter(Collision collision)
    {
        onEnter?.Invoke(collision);
    }

    protected virtual void OnExit(Collision collision)
    {
        onExit?.Invoke(collision);
    }
}
