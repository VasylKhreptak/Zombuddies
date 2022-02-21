using UnityEngine;

[CreateAssetMenu(fileName = "CollisionComponentData", menuName = "ScriptableObjects/CollisionComponentData")]
public class CollisionComponentData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private LayerMask _layerMask;
    
    public LayerMask LayerMask => _layerMask;
}
