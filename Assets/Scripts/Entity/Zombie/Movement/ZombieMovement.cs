using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public class ZombieMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private NavMeshAgent _agent;

    [Header("Preferences")]
    [SerializeField] private float _minDelay = 0.5f;
    [SerializeField] private float _maxDelay = 5f;
    [SerializeField] private float _maxDistance = 20;

    [Inject] private ZombieTargetsProvider _targetsProvider;
    
    private Coroutine _setDestinationCoroutine;

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

    private void StartSettingDestination()
    {
        if (_setDestinationCoroutine == null)
        {
            _setDestinationCoroutine = StartCoroutine(SetDestinationRoutine());
        }
    }

    private void StopSettingsDestination()
    {
        if (_setDestinationCoroutine != null)
        {
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

        float unclampedDelay = distanceToTarget / _maxDistance * _maxDelay;

        return Mathf.Clamp(unclampedDelay, _minDelay, _maxDelay);
    }


    private void OnDrawGizmosSelected()
    {
        if (_targetsProvider == null) return;
        
        Transform closestTarget = _targetsProvider.GetClosestTarget(_transform);
        
        if (closestTarget == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(closestTarget.position, _maxDistance);
    }
}