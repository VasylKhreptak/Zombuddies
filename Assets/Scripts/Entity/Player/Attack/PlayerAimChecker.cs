using UnityEngine;

public class PlayerAimChecker : AimChecker
{
    [Header("References")]
    [SerializeField] private AttackArea _attackArea;

    #region MonoBehaviour

    protected override void OnEnable()
    {
        _attackArea.onEnterFirst += StartChecking;
        _attackArea.onExitLast += StopChecking;
    }

    protected override void OnDisable()
    {
        _attackArea.onEnterFirst -= StartChecking;
        _attackArea.onExitLast -= StopChecking;
    }

    #endregion

    #region OverloadedMethods

    private void StartChecking(Transform target) => StartChecking();

    private void StopChecking(Transform target) => StopChecking();

    #endregion
}
