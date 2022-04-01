using UnityEngine;

public class ContinuousRotation : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    
    [Header("Preferences")]
    [SerializeField] private Vector3 _axis;
    [SerializeField] private float _speed;

    private Coroutine _rotateCoroutine;

    #region MonoBehaviour
    
    private void OnValidate()
    {
        _transform ??= GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    #endregion

    private void Rotate()
    {
        Quaternion rotation = _transform.rotation;

        rotation = Quaternion.AngleAxis(_speed, _axis) * rotation;

        _transform.rotation = rotation;
    }
}
