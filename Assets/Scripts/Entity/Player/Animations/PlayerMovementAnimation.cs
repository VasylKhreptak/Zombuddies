using System.Collections;
using UnityEngine;

public class PlayerMovementAnimation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Animator _animator;
    [SerializeField] private Rigidbody _rigidbody;

    [Header("Preferences")]
    [SerializeField] private string _animatorParameter = "Velocity";
    [SerializeField] private float _delay = 0.1f;

    private Coroutine _updateCoroutine;
    
    #region MonoBehaviour
 
    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        StartUpdating();
    }

    private void OnDisable()
    {
        StopUpdating();
    }

    #endregion

    private void StartUpdating()
    {
        if (_updateCoroutine == null)
        {
            _updateCoroutine = StartCoroutine(UpdateRoutine());
        }
    }

    private void StopUpdating()
    {
        if (_updateCoroutine != null)
        {
            StopCoroutine(_updateCoroutine);

            _updateCoroutine = null;
        }
    }

    private IEnumerator UpdateRoutine()
    {
        while (true)
        {
            UpdateValue();

            yield return new WaitForSeconds(_delay);
        }
    }

    private void UpdateValue()
    {
        _animator.SetFloat(_animatorParameter, _rigidbody.velocity.magnitude / _playerMovement.MaxSpeed);
    }
}
