using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _spineTransform;
    [SerializeField] private AttackArea _attackArea;

    [Header("Preferences")]
    [SerializeField] private float _aimSpeed = 0.1f;
    
    #region MonoBaheviour

    private void Update()
    {
        if (CanAim())
        {
            Aim();
        }
    }

    #endregion

    private bool CanAim()
    {
        return _attackArea.IsEmpty == false && _attackArea.closestTarget != null;
    }
    
    private void Aim()
    {
        Vector3 directionToTarget = _attackArea.closestTarget.position - _transform.position;

        directionToTarget  = Vector3.Scale(directionToTarget, new Vector3(1, 0, 1));
        
        Quaternion rotation = Quaternion.LookRotation(directionToTarget);
        
        _spineTransform.rotation = Quaternion.Lerp(_transform.rotation, rotation, Time.deltaTime * _aimSpeed);
        
        Debug.DrawRay(_transform.position, directionToTarget * 5f, Color.green, 1f);
    }
}
