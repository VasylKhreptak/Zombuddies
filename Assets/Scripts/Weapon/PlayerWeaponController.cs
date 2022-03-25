using System;
using UnityEngine;
using Zenject;

public class PlayerWeaponController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Weapon _weapon;
    [SerializeField] private AimChecker _aim;
    
    private Joystick _joystick;

    [Inject]
    private void Construct(Joystick joystick)
    {
        _joystick = joystick;
    }
    
    #region MonoBehaviour

    private void OnValidate()
    {
        _weapon ??= GetComponent<Weapon>();
        _aim ??= GetComponent<AimChecker>();
    }

    private void OnEnable()
    {
        _aim.onAimEnter += _weapon.StartShooting;
        _aim.onAimExit += _weapon.StopShooting;
        _joystick.onPointerDown += _weapon.StopShooting;
        _joystick.onPointerUp += TryStartShooting;
    }

    private void OnDisable()
    {
        _aim.onAimEnter -= _weapon.StartShooting;
        _aim.onAimExit -= _weapon.StopShooting;
        _joystick.onPointerDown -= _weapon.StopShooting;
        _joystick.onPointerUp -= TryStartShooting;
    }

    #endregion

    private void TryStartShooting()
    {
        if (CanStartShooting())
        {
            _weapon.StartShooting();
        }
    }

    private bool CanStartShooting() => _aim.aimed && _joystick.IsMoving == false;
}
