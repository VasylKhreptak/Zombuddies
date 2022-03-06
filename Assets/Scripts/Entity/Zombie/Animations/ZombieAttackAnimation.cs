using System.Collections;
using UnityEngine;

public class ZombieAttackAnimation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TriggerComponent _attackZone;
    [SerializeField] private Animator _animator;

    [Header("Data")]
    [SerializeField] private ZombieAttackAnimationData _data;

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
                yield return new WaitForSeconds(_data.AnimateDelay);
                continue;
            }
            
            Animate();

            yield return new WaitForSeconds(_data.AnimateDelay);
        }
    }

    private void Animate()
    {
        _animator.SetInteger(_data.AttackIndexParameter, Random.Range(_data.MinAtackIndex, _data.MaxAtackIndex  + 1));
        _animator.SetTrigger(_data.AnimatorAtackParameter);
    }
}
