using UnityEngine;

[CreateAssetMenu(fileName = "ZombieRandomMovementData", menuName = "ScriptableObjects/ZombieRandomMovementData")]
public class ZombieRandomMovementData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private float _minSetDestinationDelay;
    [SerializeField] private float _maxSetDestinationDelay;
    [SerializeField] private float _range;
    
    public float MinSetDestinationDelay => _minSetDestinationDelay;
    public float MaxSetDestinationDelay => _maxSetDestinationDelay;
    public float Range => _range;
}
