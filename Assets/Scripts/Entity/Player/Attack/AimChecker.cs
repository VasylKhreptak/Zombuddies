using System;
using System.Collections;
using UnityEngine;

public class AimChecker : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _startTransform;

    [Header("Preferences")]
    [SerializeField] private float _rayOriginOffset = 2.21f;
    [SerializeField] private float _rayLength = 10f;
    [SerializeField] private float _checkDelay = 0.2f;
    [SerializeField] private LayerMask _targetLayerMask;
    [SerializeField] private LayerMask _environmentLayerMask;

    private Coroutine _checkCoroutine;

    public bool aimed { get; private set; }

    public Action onAimEnter;
    public Action onAimExit;

    #region MonoBehaviour

    protected virtual void OnEnable()
    {
        StartChecking();
    }

    protected virtual void OnDisable()
    {
        StopChecking();
    }

    #endregion

    protected void StartChecking()
    {
        if (_checkCoroutine == null)
        {
            _checkCoroutine = StartCoroutine(CheckRoutine());
        }
    }

    protected void StopChecking()
    {
        if (_checkCoroutine != null)
        {
            StopCoroutine(_checkCoroutine);

            _checkCoroutine = null;
        }

        aimed = false;
    }

    private IEnumerator CheckRoutine()
    {
        while (true)
        {
            Check();

            yield return new WaitForSeconds(_checkDelay);
        }
    }

    private void Check()
    {
        Ray ray = new Ray(_startTransform.position + _startTransform.forward * _rayOriginOffset, _startTransform.forward);

        Physics.Raycast(ray, out RaycastHit hitInfo, _rayLength, _environmentLayerMask);

        bool hitTarget = HitTarget(hitInfo);

        TryInvokeEvent(aimed, hitTarget);

        aimed = hitTarget;
    }

    private bool HitTarget(RaycastHit hitInfo)
    {
        if (hitInfo.collider == null)
        {
            return false;
        }

        return _targetLayerMask.ContainsLayer(hitInfo.collider.gameObject.layer);
    }

    private void TryInvokeEvent(bool previousValue, bool currentValue)
    {
        if (previousValue == false && currentValue)
        {
            onAimEnter?.Invoke();
        }
        else if (previousValue && currentValue == false)
        {
            onAimExit?.Invoke();
        }
    }

    private void OnDrawGizmosSelected()
    {
        bool CanDraw() => _startTransform != null;

        if (CanDraw() == false) return;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(_startTransform.position +_startTransform.forward * _rayOriginOffset, _startTransform.forward * _rayLength);
    }
}
