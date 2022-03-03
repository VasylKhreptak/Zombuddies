using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Zenject;

public class PlayerAimRigWeight : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rig _rig;
    [SerializeField] private TriggerArea _attackArea;

    [Header("Preferences")]
    [SerializeField] private float _startDelay = 0.7f;
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private AnimationCurve _animationCurve;

    [Inject] private Joystick _joystick;

    private Tween _tween;

    #region MonoBehaviour

    private void Awake()
    {
        _rig.weight = 0f;
    }

    private void OnValidate()
    {
        _rig ??= GetComponent<Rig>();
    }

    private void OnEnable()
    {
        _attackArea.onEnterFirst += TryEnableAimingWithDelay;
        _attackArea.onExitLast += DisableAiming;
        _joystick.onPointerDown += DisableAiming;
        _joystick.onPointerUp += TryEnableAiming;
    }

    private void OnDisable()
    {
        _attackArea.onEnterFirst -= TryEnableAimingWithDelay;
        _attackArea.onExitLast -= DisableAiming;
        _joystick.onPointerDown -= DisableAiming;
        _joystick.onPointerUp -= TryEnableAiming;
    }

    private void OnDestroy()
    {
        _tween.Kill();
    }

    #endregion

    #region OverloadedMethods

    private void EnableAiming() => SetWeight(1f);
    
    private void DisableAiming() => SetWeight(0f);

    private void DisableAiming(Transform target) => DisableAiming();
    
    private void EnableAimingWithDelay() => SetWeight(1f, _startDelay);
    
    private void DisableAimingWithDelay() => SetWeight(0f, _startDelay);
    
    private void TryEnableAiming()
    {
        if (CanEnableAiming())
        {
            EnableAiming();
        }
    }

    private void TryEnableAimingWithDelay()
    {
        if (CanEnableAiming())
        {
            EnableAimingWithDelay();
        }
    }

    private void TryEnableAimingWithDelay(Transform target) => TryEnableAimingWithDelay();
    
    #endregion

    private bool CanEnableAiming() => _joystick.IsMoving == false && _attackArea.IsEmpty == false;

    private void SetWeight(float weight, float delay = 0f)
    {
        DOTween.To(() => _rig.weight, x => _rig.weight = x, weight, _duration).SetEase(_animationCurve).SetDelay(delay);
    }
}
