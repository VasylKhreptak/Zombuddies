using System;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    public bool isInTrigger { get; private set; }

    [Header("Data")]
    [SerializeField] private TriggerCheckerData _triggerCheckerData;

    #region MonoBehaviour

    private void OnTriggerEnter(Collider other)
    {
        if (_triggerCheckerData.LayerMask.ContainsLayer(other.gameObject.layer))
        {
            isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_triggerCheckerData.LayerMask.ContainsLayer(other.gameObject.layer))
        {
            isInTrigger = false;
        }
    }

    #endregion
}