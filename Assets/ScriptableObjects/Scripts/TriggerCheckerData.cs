using UnityEngine;

[CreateAssetMenu(fileName = "TriggerCheckerData", menuName = "ScriptableObjects/TriggerCheckerData")]
public class TriggerCheckerData : ScriptableObject
{
    [SerializeField] private LayerMask _layerMask;

    public LayerMask LayerMask => _layerMask;
}
