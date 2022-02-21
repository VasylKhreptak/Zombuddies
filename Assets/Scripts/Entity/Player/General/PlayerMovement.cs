using UnityEngine;
using Zenject;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private Rigidbody _rigidbody;

    [Header("Movement Preferences")]
    [SerializeField] private float _force = 10f;
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private ForceMode _forceMode = ForceMode.VelocityChange;

    [Header("Rotation Preferences")]
    [SerializeField, Range(0f, 1f)]
    private float _rotationSpeed;

    [Inject] private Joystick _joystick;

    public float MaxSpeed => _maxSpeed;

    #region MonoBaheviour

    private Transform _cameraTransform;

    private void Awake()
    {
        _cameraTransform = Camera.main.transform;
    }

    private void OnValidate()
    {
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_joystick.IsMoving == false) return;

        Move();

        AssignLook();
    }

    #endregion

    private void Move()
    {
        _rigidbody.AddForce(GetJoystickDirection() * _force, _forceMode);

        _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, _maxSpeed);
    }

    private void AssignLook()
    {
        Vector3 lookDirection = GetJoystickDirection();

        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);

        _transform.rotation = Quaternion.Lerp(_transform.rotation, lookRotation, _rotationSpeed);
    }

    private Vector3 GetJoystickDirection()
    {
        Vector3 direction = _transform.position - _cameraTransform.position;

        direction.Scale(new Vector3(1, 0, 1));

        float angle = -Vector2.SignedAngle(Vector2.up, _joystick.Direction);

        direction = Quaternion.AngleAxis(angle, Vector3.up) * direction;

        direction.Normalize();

        return direction;
    }

    private void GetMovementDirection()
    {
    }
}