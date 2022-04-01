using System;
using UnityEngine;

public class TransformPositionLinker : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _linkToTransform;

    #region MonoBehaviour

    private void OnValidate()
    {
        _transform ??= GetComponent<Transform>();
        _linkToTransform ??= _transform.root;
    }

    private void Update()
    {
        _transform.position = _linkToTransform.position;
    }

    #endregion
}
