using UnityEngine;

[CreateAssetMenu(fileName = "GroundCheckerData", menuName = "ScriptableObjects/GroundCheckerData")]
public class GroundCheckerData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private float _startOffset = 1f;
    [SerializeField] private float _rayLength = 1f;
    [SerializeField] private LayerMask _groundLayerMask;
    
    public float StartOffset => _startOffset;
    public float RayLength => _rayLength;
    public LayerMask GroundLayerMask => _groundLayerMask;
}
