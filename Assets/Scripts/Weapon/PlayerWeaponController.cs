using System;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Weapon _weapon;
    [SerializeField] private AimChecker _aim;

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
    }

    private void OnDisable()
    {
        _aim.onAimEnter -= _weapon.StartShooting;
        _aim.onAimExit -= _weapon.StopShooting;
    }

    #endregion
}
