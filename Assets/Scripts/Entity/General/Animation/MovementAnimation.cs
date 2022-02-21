using System.Collections;
using UnityEngine;

public class MovementAnimation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator _animator;
    [SerializeField] private SpeedAdapter _speedAdapter;

    [Header("Preferences")]
    [SerializeField] private string _animatorParameter = "Velocity";
    [SerializeField] private float _delay = 0.1f;

    private Coroutine _updateCoroutine;

    #region MonoBehaviour

    private void OnValidate()
    {
        _animator = GetComponent<Animator>();
        _speedAdapter = GetComponent<SpeedAdapter>();
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
        float speed = _speedAdapter.velocity.magnitude;
        
        _animator.SetFloat(_animatorParameter, speed);
    }
}
