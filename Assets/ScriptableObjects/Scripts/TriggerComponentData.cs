using UnityEngine;

[CreateAssetMenu(fileName = "TriggerComponentData", menuName = "ScriptableObjects/TriggerComponentData")]
public class TriggerComponentData : ScriptableObject
{
    [SerializeField] private LayerMask _layerMask;

    public LayerMask LayerMask => _layerMask;
}
