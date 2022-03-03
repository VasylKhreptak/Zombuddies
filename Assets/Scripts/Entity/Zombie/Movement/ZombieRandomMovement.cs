using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class ZombieRandomMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private ZombieTargetFollow _zombieTargetFollow;
    [SerializeField] private NavMeshAgent _agent;

    [Header("Data")]
    [SerializeField] private ZombieRandomMovementData _movementData;


    private Coroutine _randomMovementCoroutine;

    #region MonoBehaviour

    private void OnValidate()
    {
        _transform ??= GetComponent<Transform>();
        _zombieTargetFollow ??= GetComponent<ZombieTargetFollow>();
        _agent ??= GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        _zombieTargetFollow.onStartFollow += StopRandomMovement;
        _zombieTargetFollow.onStopFollow += StartRandomMovement;
    }

    private void OnDisable()
    {
        StopRandomMovement();
        
        _zombieTargetFollow.onStartFollow -= StopRandomMovement;
        _zombieTargetFollow.onStopFollow -= StartRandomMovement;
    }

    #endregion

    private void StartRandomMovement()
    {
        if (_randomMovementCoroutine == null && gameObject.activeSelf)
        {
            _randomMovementCoroutine = StartCoroutine(RandomMovementRoutine());
        }
    }

    private void StopRandomMovement()
    {
        if (_randomMovementCoroutine != null)
        {
            StopCoroutine(_randomMovementCoroutine);

            _randomMovementCoroutine = null;
        }
    }

    private IEnumerator RandomMovementRoutine()
    {
        while (true)
        {
            SetRandomDestination();

            yield return new WaitForSeconds(Random.Range(_movementData.MinSetDestinationDelay,
                _movementData.MaxSetDestinationDelay));
        }
    }

    private void SetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * _movementData.Range;

        Vector3 destination = _transform.position + randomDirection;

        _agent.SetDestination(destination);
    }

    private void OnDrawGizmosSelected()
    {
        bool CanDraw() => _transform != null;
        
        if (CanDraw() == false) return;
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_transform.position, _movementData.Range);
    }
}
