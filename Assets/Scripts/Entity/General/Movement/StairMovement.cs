using System;
using UnityEngine;
using Zenject;

public class StairMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private TriggerComponent _upperTrigger;
    [SerializeField] private TriggerComponent _lowerTrigger;

    [Header("Stair Movement Preferences")]
    [SerializeField] private float _smooth = 0.1f;

    private Joystick _joystick;

    [Inject]
    private void Construct(Joystick joystick)
    {
        _joystick = joystick;
    }
    
    #region MonoBehaviour

    private void OnValidate()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_joystick.IsMoving == false) return;

        if (_upperTrigger.isInTrigger == false && _lowerTrigger.isInTrigger)
        {
            _rigidbody.position += new Vector3(0, _smooth, 0);
        }
    }

    #endregion
}