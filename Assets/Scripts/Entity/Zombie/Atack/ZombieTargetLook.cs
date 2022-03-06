using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class ZombieTargetLook : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private TriggerComponent _attackArea;

    [Header("Data")]
    [SerializeField] private ZombieTargetLookData _data;
    
    [Inject] private ZombieTargetsProvider _targetsProvider;

    private Coroutine _lookCoroutine;

    #region MonoBehaviour

    private void OnValidate()
    {
        _transform ??= GetComponent<Transform>();
    }

    private void OnEnable()
    {
        _attackArea.onEnter += StartLooking;
        _attackArea.onExit += StopLooking;
    }

    private void OnDisable()
    {
        _attackArea.onEnter += StartLooking;
        _attackArea.onExit += StopLooking;
    }

    #endregion

    private void StartLooking(Collider collider) => StartLooking(collider.transform);

    private void StopLooking(Collider collider) => StopLooking();
    
    private void StartLooking(Transform target)
    {
        if (_lookCoroutine == null)
        {
            _lookCoroutine = StartCoroutine(LookRoutine(target));
        }
    }

    private void StopLooking()
    {
        if (_lookCoroutine != null)
        {
            StopCoroutine(_lookCoroutine);

            _lookCoroutine = null;
        }
    }

    private IEnumerator LookRoutine(Transform target)
    {
        while (true)
        {
            if (CanLook(target))
            {
                Look(target);
            }
            else
            {
                StopLooking();
            }
            
            yield return null;
        }
    }

    private bool CanLook(Transform target) => target.gameObject.IsValid();

    private void Look(Transform target)
    {
        Vector3 directionToTarget = target.position - _transform.position;

        directionToTarget  = Vector3.Scale(directionToTarget, new Vector3(1, 0, 1));
        
        Quaternion rotation = Quaternion.LookRotation(directionToTarget);
        
        _transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, Time.deltaTime * _data.LookSpeed);
    }
}
