using UnityEngine;

[CreateAssetMenu(fileName = "GroundCheckerData", menuName = "ScriptableObjects/GroundCheckerData")]
public class GroundCheckerData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private LayerMask _groundLayerMask;
    
    public LayerMask GroundLayerMask => _groundLayerMask;
}
