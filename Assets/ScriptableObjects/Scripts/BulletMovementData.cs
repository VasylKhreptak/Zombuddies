using UnityEngine;

[CreateAssetMenu(fileName = "BulletMovementData", menuName = "ScriptableObjects/BulletMovementData")]
public class BulletMovementData : ScriptableObject
{
    [Header("Preferences")]
    [SerializeField] private float _force;
    [SerializeField] private ForceMode _forceMode;
    
    [Header("Scatter Preferences")]
    [SerializeField] private float _minScatterAngle;
    [SerializeField] private float _maxScatterAngle;
    
    public float ScatterAngle => Random.Range(_minScatterAngle, _maxScatterAngle);
    public float Force => _force;
    public ForceMode ForceMode => _forceMode;
}
