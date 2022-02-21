using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;

    [Header("Preferences")]
    [SerializeField] private float _startOffset = 1f;
    [SerializeField] private float _rayLength = 1f;
    
    [Header("Data")]
    [SerializeField] private GroundCheckerData _checkerData;
    
    #region MonoBehaviour

    private void OnValidate()
    {
        _transform ??= GetComponent<Transform>();
    }

    #endregion

    public bool IsGrounded()
    {
        Ray ray = new Ray(_transform.position + new Vector3(0, _startOffset, 0),
            Vector3.down);
        
        return Physics.Raycast(ray, _rayLength, _checkerData.GroundLayerMask);
    }

    private void OnDrawGizmosSelected()
    {
        if (_transform == null) return;
        
        Gizmos.color = Color.green;
        Gizmos.DrawRay(_transform.position + new Vector3(0, _startOffset, 0),
            Vector3.down * _rayLength);
    }
}
