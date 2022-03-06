using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;

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
        Ray ray = new Ray(_transform.position + new Vector3(0, _checkerData.StartOffset, 0),
            Vector3.down);
        
        return Physics.Raycast(ray, _checkerData.RayLength, _checkerData.GroundLayerMask);
    }

    private void OnDrawGizmosSelected()
    {
        if (_transform == null) return;
        
        Gizmos.color = Color.green;
        Gizmos.DrawRay(_transform.position + new Vector3(0, _checkerData.StartOffset, 0),
            Vector3.down * _checkerData.RayLength);
    }
}
