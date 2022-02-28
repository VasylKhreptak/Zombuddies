using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private TriggerData _triggerData;
    
    public Action<Collider> onEnter;
    public Action<Collider> onExit;
    
    #region MonoBehaviour

    private void OnTriggerEnter(Collider other)
    {
        if (CanRegister(other))
        {
            OnEnter(other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (CanRegister(other))
        {
            OnExit(other);
        }
    }

    #endregion

    private bool CanRegister(Collider coll)
    {
        return _triggerData.LayerMask.ContainsLayer(coll.gameObject.layer);
    }
    
    protected virtual void OnEnter(Collider collider)
    {
        onEnter?.Invoke(collider);
    }

    protected virtual void OnExit(Collider collider)
    {
        onExit?.Invoke(collider);
    }
}
