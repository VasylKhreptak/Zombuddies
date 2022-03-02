using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerBodyAim : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private AttackArea _attackArea;

    [Header("Preferences")]
    [SerializeField] private float _aimSpeed = 0.1f;
    [SerializeField] private Vector3 _offset;

    [Inject] private Joystick _joystick;
    
    private Coroutine _aimCoroutine;
    
    #region MonoBaheviour

    private void OnEnable()
    {
        _attackArea.onEnterFirst += StartAiming;
        _attackArea.onExitLast += StopAiming;
    }

    private void OnDisable()
    {
        _attackArea.onEnterFirst -= StartAiming;
        _attackArea.onExitLast -= StopAiming;
    }

    #endregion

    private void StartAiming(Transform target) => StartAiming();
    private void StopAiming(Transform target) => StopAiming();
    
    private void StartAiming()
    {
        if (_aimCoroutine == null)
        {
            _aimCoroutine = StartCoroutine(AimRoutine());
        }
    }

    private void StopAiming()
    {
        if (_aimCoroutine != null)
        {
            StopCoroutine(_aimCoroutine);
            
            _aimCoroutine = null;
        }
    }

    private IEnumerator AimRoutine()
    {
        while (true)
        {
            TryAim();
            
            yield return null;
        }
    }

    private void TryAim()
    {
        if (CanAim())
        {
            Aim(); 
        }
    }
    
    private bool CanAim()
    {
        return _attackArea.closestTarget != null && _joystick.IsMoving == false;
    }
    
    private void Aim()
    {
        Vector3 directionToTarget = _attackArea.closestTarget.position - _transform.position;

        directionToTarget  = Vector3.Scale(directionToTarget, new Vector3(1, 0, 1));
        
        Quaternion rotation = Quaternion.LookRotation(directionToTarget);
        
        _transform.rotation = Quaternion.Lerp(_transform.rotation, rotation, Time.deltaTime * _aimSpeed);
        
        _transform.rotation = Quaternion.Euler(_transform.rotation.eulerAngles + _offset);
    }
}
