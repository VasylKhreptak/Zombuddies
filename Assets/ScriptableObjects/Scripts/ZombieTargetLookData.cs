using UnityEngine;

[CreateAssetMenu(fileName = "ZombieTargetLookData", menuName = "ScriptableObjects/ZombieTargetLookData")]
public class ZombieTargetLookData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private float _lookSpeed;
    
    public float LookSpeed => _lookSpeed;
}
