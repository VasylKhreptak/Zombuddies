using System.Collections;
using UnityEngine;

public class ZombieAtackAnimation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TriggerComponent _triggerComponent;
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
        _triggerComponent ??= GetComponent<TriggerComponent>();
    }

    private void OnEnable()
    {
        _triggerComponent.onEnter += StartAnimating;
        _triggerComponent.onExit += StopAnimating;
    }

    private void OnDisable()
    {
        _triggerComponent.onEnter -= StartAnimating;
        _triggerComponent.onExit -= StopAnimating;
    }

    #endregion

    private void StartAnimating(Collider collider)
    {
        if (_animateCoroutine == null)
        {
            _animateCoroutine = StartCoroutine(AnimateRoutine());
        }
    }

    private void StopAnimating(Collider collider)
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
