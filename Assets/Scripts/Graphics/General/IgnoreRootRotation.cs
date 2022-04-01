using System;
using UnityEngine;

[RequireComponent(typeof(TransformPositionLinker))]
[RequireComponent(typeof(OnEnableEventLinker))]
[RequireComponent(typeof(OnDisableEventLinker))]
[RequireComponent(typeof(OnDestroyEventLinker))]
public class IgnoreRootRotation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;

    #region MonoBehaviour

    private void OnValidate()
    {
        _transform ??= GetComponent<Transform>();
    }

    private void Awake()
    {
        _transform.SetParent(null);
    }

    #endregion
}