using System.Collections;
using UnityEngine;

public class ZombieAtackAnimation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TriggerComponent _attackZone;
    [SerializeField] private Animator _animator;
    
    [Header("Preferences")]
    [SerializeField] private string _animatorAtackParameter;
    [SerializeField] private string _atackIndexParameter;
    [SerializeField] private int _minAtackIndex;
    [SerializeField] private int _maxAtackIndex;
    [SerializeField] private float _animateDelay = 2f;

    private Coroutine _animateCoroutine;
    
    #region MonoBehaviour

    private void OnValidate()
    {
        _attackZone ??= GetComponent<TriggerComponent>();
    }

    private void OnEnable()
    {
        _attackZone.onEnter += StartAnimating;
        _attackZone.onExit += StopAnimating;
    }

    private void OnDisable()
    {
        _attackZone.onEnter -= StartAnimating;
        _attackZone.onExit -= StopAnimating;
    }

    #endregion

    private void StartAnimating(Collider collider) => StartAnimating();
    private void StopAnimating(Collider collider) => StopAnimating();

    private void StartAnimating()
    {
        if (_animateCoroutine == null)
        {
            _animateCoroutine = StartCoroutine(AnimateRoutine());
        }
    }

    private void StopAnimating()
    {
        if (_animateCoroutine != null)
        {
            StopCoroutine(_animateCoroutine);

            _animateCoroutine = null;
        }
    }

    private IEnumerator AnimateRoutine()
    {
        while (true)
        {
            if (_attackZone.affectedObject == null || _attackZone.affectedObject.gameObject.activeSelf == false)
            {
                yield return new WaitForSeconds(_animateDelay);
                continue;
            }
            
            Animate();

            yield return new WaitForSeconds(_animateDelay);
        }
    }

    private void Animate()
    {
        _animator.SetInteger(_atackIndexParameter, Random.Range(_minAtackIndex, _maxAtackIndex  + 1));
        _animator.SetTrigger(_animatorAtackParameter);
    }
}
