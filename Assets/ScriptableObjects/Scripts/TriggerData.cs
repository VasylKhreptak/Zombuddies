using UnityEngine;

[CreateAssetMenu(fileName = "TriggerData", menuName = "ScriptableObjects/TriggerData")]
public class TriggerData : ScriptableObject
{
    [SerializeField] private LayerMask _layerMask;

    public LayerMask LayerMask => _layerMask;
}
