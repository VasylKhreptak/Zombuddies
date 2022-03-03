using UnityEngine;

[CreateAssetMenu(fileName = "CollisionDetectorData", menuName = "ScriptableObjects/CollisionDetectorData")]
public class CollisionDetectorData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private LayerMask _layerMask;
    
    public LayerMask LayerMask => _layerMask;
}
