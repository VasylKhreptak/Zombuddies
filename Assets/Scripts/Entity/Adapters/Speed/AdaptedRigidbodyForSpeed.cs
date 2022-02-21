using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdaptedRigidbodyForSpeed : SpeedAdapter
{

    [Header("References")]
    [SerializeField] private Rigidbody _rigidbody;

    #region MonoBehaviour

    private void OnValidate()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    #endregion
    
    public override Vector3 velocity
    {
        get => _rigidbody.velocity;
        set => _rigidbody.velocity = value;
    }
}
