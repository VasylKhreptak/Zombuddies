using UnityEngine;

[CreateAssetMenu(fileName = "DamageableObjectData", menuName = "ScriptableObjects/DamageableObjectData")]
public class DamageableObjectData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private float _maxHealth = 100f;
    
    public float MaxHealth => _maxHealth;
}
