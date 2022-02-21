using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private NavMeshAgent _agent;

    [Header("Preferences")]
    [SerializeField] private float _minDelay = 0.5f;
    [SerializeField] private float _maxDelay = 5f;
    [SerializeField] private float _maxDistance = 20;

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
    }

    private void OnDisable()
    {
        StopSettingsDestination();
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
            _agent.SetDestination(_targetTransform.position);
            
            yield return new WaitForSeconds(GetDelay());
        }
    }

    private float GetDelay()
    {
        float distanceToTarget = Vector3.Distance(_transform.position, _targetTransform.position);

        float unclampedDelay = distanceToTarget / _maxDistance * _maxDelay;

        return Mathf.Clamp(unclampedDelay, _minDelay, _maxDelay);
    }


    private void OnDrawGizmosSelected()
    {
        if (_targetTransform == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_targetTransform.position, _maxDistance);
    }
}