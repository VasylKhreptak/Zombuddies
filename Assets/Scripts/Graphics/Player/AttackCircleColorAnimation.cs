using System;
using UnityEngine;

public class AttackCircleColorAnimation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private ColorAnimation _colorAnimation;
    [SerializeField] private AttackArea _triggerArea;

    #region MonoBehaviour

    private void OnValidate()
    {
        _colorAnimation ??= GetComponent<ColorAnimation>();
    }

    private void OnEnable()
    {
        _triggerArea.onEnterFirst += StartAnimation;
        _triggerArea.onExitLast += StartReversedAnimation;
        _triggerArea.onBecameEmpty += StartReversedAnimation;

    }

    private void OnDisable()
    {
        _triggerArea.onEnterFirst -= StartAnimation;
        _triggerArea.onExitLast -= StartReversedAnimation;
        _triggerArea.onBecameEmpty -= StartReversedAnimation;
    }
    
    #endregion
    
    private void StartAnimation() => _colorAnimation.Animate(true);

    private void StartReversedAnimation() => _colorAnimation.Animate(false);
    
    private void StartAnimation(Transform target) => StartAnimation();
    
    private void StartReversedAnimation(Transform target) => StartReversedAnimation();
}