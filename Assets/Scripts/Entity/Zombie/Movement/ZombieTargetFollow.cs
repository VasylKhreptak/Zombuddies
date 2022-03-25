using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class ZombieTargetFollow : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private NavMeshAgent _agent;

    [Header("Preferences")]
    [SerializeField] private float _minSetDestinationDelay = 0.5f;
    [SerializeField] private float _maxSetDestinationDelay = 5f;
    [SerializeField] private float _maxDistance = 20;

    private ZombieTargetsProvider _targetsProvider;

    private Coroutine _setDestinationCoroutine;

    public Action onStartFollow;
    public Action onStopFollow;

    [Inject]
    private void Construct(ZombieTargetsProvider targetsProvider)
    {
        _targetsProvider = targetsProvider;
    }

    #region MonoBehaviour

    private void OnValidate()
    {
        _transform = GetComponent<Transform>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        StartSettingDestination();

        _targetsProvider.onAddTarget += StartSettingDestination;
    }

    private void OnDisable()
    {
        StopSettingsDestination();

        _targetsProvider.onAddTarget -= StartSettingDestination;
    }

    #endregion

    private void StartSettingDestination(Transform target) => StartSettingDestination();

    private void StartSettingDestination()
    {
        if (_setDestinationCoroutine == null)
        {
            onStartFollow?.Invoke();

            _setDestinationCoroutine = StartCoroutine(SetDestinationRoutine());
        }
    }

    private void StopSettingsDestination()
    {
        if (_setDestinationCoroutine != null)
        {
            onStopFollow?.Invoke();

            StopCoroutine(_setDestinationCoroutine);

            _setDestinationCoroutine = null;
        }
    }

    private IEnumerator SetDestinationRoutine()
    {
        while (true)
        {
            Transform closestTarget = _targetsProvider.GetClosestTarget(_transform);

            if (closestTarget == null)
            {
                StopSettingsDestination();

                break;
            }

            _agent.SetDestination(closestTarget.position);

            yield return new WaitForSeconds(GetDelay(closestTarget));
        }
    }

    private float GetDelay(Transform target)
    {
        float distanceToTarget = Vector3.Distance(_transform.position, target.position);

        float unclampedDelay = distanceToTarget / _maxDistance * _maxSetDestinationDelay;

        return Mathf.Clamp(unclampedDelay, _minSetDestinationDelay, _maxSetDestinationDelay);
    }


    private void OnDrawGizmosSelected()
    {
        bool CanDraw() => _targetsProvider != null;

        if (CanDraw() == false) return;

        Transform closestTarget = _targetsProvider.GetClosestTarget(_transform);

        if (closestTarget == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(closestTarget.position, _maxDistance);
    }
}
