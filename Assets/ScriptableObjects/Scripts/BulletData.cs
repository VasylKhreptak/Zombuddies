using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "ScriptableObjects/BulletData")]
public class BulletData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private float _minDamage = 5f;
    [SerializeField] private float _maxDamage = 12f;
    
    public float MinDamage => _minDamage;
    public float MaxDamage => _maxDamage;
}
