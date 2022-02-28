using System.Collections;
using UnityEngine;

public class AttackArea : TriggerArea
{
    [Header("References")]
    [SerializeField] private Transform _transform;

    [Header("Preferences")]
    [SerializeField] private float _findDelay = 1f;

    public Transform closestTarget;

    private Coroutine _findTargetCoroutine;

    #region MonoBehaviour
    
    private void OnDisable()
    {
        StopFindingClosestTarget();
    }

    #endregion

    protected override void OnEnter(Collider collider)
    {
        if (IsEmpty)
        {
            StartFindingClosestTarget();
        }

        base.OnEnter(collider);
    }

    protected override void OnExit(Collider collider)
    {
        base.OnExit(collider);

        if (IsEmpty)
        {
            StopFindingClosestTarget();
        }
    }

    private void StartFindingClosestTarget()
    {
        if (_findTargetCoroutine == null)
        {
            _findTargetCoroutine = StartCoroutine(FindClosestTargetRoutine());
        }
    }

    private void StopFindingClosestTarget()
    {
        if (_findTargetCoroutine != null)
        {
            StopCoroutine(_findTargetCoroutine);

            _findTargetCoroutine = null;

            closestTarget = null;
        }
    }

    private IEnumerator FindClosestTargetRoutine()
    {
        while (true)
        {
            if (IsEmpty == false)
            {
                AssignTarget();
            }

            yield return new WaitForSeconds(_findDelay);
        }
    }

    private void AssignTarget()
    {
        closestTarget = _transform.FindClosestTransform(affectedObjects.ToArray())?.root;
    }
}
