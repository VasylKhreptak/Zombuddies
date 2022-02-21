using System;
using UnityEngine;

public class TriggerComponent : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private TriggerComponentData _triggerComponentData;

    public bool isInTrigger { get; private set; }

    public Action<Collider> onEnter;
    public Action<Collider> onExit;

    #region MonoBehaviour

    private void OnTriggerEnter(Collider other)
    {
        if (_triggerComponentData.LayerMask.ContainsLayer(other.gameObject.layer))
        {
            onEnter?.Invoke(other);

            isInTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_triggerComponentData.LayerMask.ContainsLayer(other.gameObject.layer))
        {
            onExit?.Invoke(other);

            isInTrigger = false;
        }
    }

    #endregion
}
