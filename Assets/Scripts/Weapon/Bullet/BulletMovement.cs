using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class BulletMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private Rigidbody _rigidbody;

    [Header("Data")]
    [SerializeField] private BulletMovementData _data;

    #region MonoBehaviour

    private void OnValidate()
    {
        _transform ??= GetComponent<Transform>();
        _rigidbody ??= GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        ResetSpeed();
        
        SetScatter();
        
        Move();
    }

    #endregion

    private void ResetSpeed()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }

    private void SetScatter()
    {
        _transform.rotation = quaternion.LookRotation(GetBulletDirection(), Vector3.up);
    }

    private void Move()
    {
        _rigidbody.AddForce(_transform.forward * _data.Force, _data.ForceMode);
    }
    
    private Vector3 GetBulletDirection()
    {
        Vector3 direction = _transform.forward;

        direction = Quaternion.AngleAxis(_data.ScatterAngle, Random.insideUnitSphere) * direction;

        return direction;
    }
}
