using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Zenject;

public class PlayerAimTargetSetter : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AttackArea _attackArea;
    [SerializeField] private RigBuilder _rigBuilder;

    [Header("Rigs")]
    [SerializeField] private MultiAimConstraint[] _aims;

    [Header("Preferences")]
    [SerializeField] private float _updateDelay = 0.2f;

    [Inject] private Joystick _joystick;

    private Coroutine _setTargetCoroutine;

    #region MonoBehaviour

    private void OnValidate()
    {
        _rigBuilder ??= transform.root.GetComponent<RigBuilder>();
    }

    private void OnEnable()
    {
        _joystick.onPointerDown += StopSettingTarget;
        _joystick.onPointerUp += StartSettingTarget;
    }

    private void OnDisable()
    {
        _joystick.onPointerDown -= StopSettingTarget;
        _joystick.onPointerUp -= StartSettingTarget;
    }

    #endregion

    private void StartSettingTarget()
    {
        if (_setTargetCoroutine == null)
        {
            _setTargetCoroutine = StartCoroutine(SetTargetRoutine());
        }
    }

    private void StopSettingTarget()
    {
        if (_setTargetCoroutine != null)
        {
            StopCoroutine(_setTargetCoroutine);

            _setTargetCoroutine = null;
        }
    }

    private IEnumerator SetTargetRoutine()
    {
        while (true)
        {
            SetTarget(_attackArea.closestTarget);

            yield return new WaitForSeconds(_updateDelay);
        }
    }

    private void SetTarget(Transform target)
    {
        foreach (var aim in _aims)
        {
            var data = aim.data.sourceObjects;
            data.SetTransform(0, target);

            aim.data.sourceObjects = data;
        }

        _rigBuilder.Build();

        if (target == null)
        {
            Debug.Log("Name");
            return;
        }

        Debug.Log("Name: " + (target.name));
    }
}
